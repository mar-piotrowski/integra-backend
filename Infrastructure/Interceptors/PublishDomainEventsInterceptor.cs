using Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptors;

public class PublishDomainEventsInterceptor : SaveChangesInterceptor {
    private readonly IMediator _mediator;

    public PublishDomainEventsInterceptor(IMediator mediator) {
        _mediator = mediator;
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result
    ) {
        PublishDomainEvent(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken()
    ) {
        await PublishDomainEvent(eventData.Context);
        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private async Task PublishDomainEvent(DbContext? dbContext) {
        if (dbContext is null)
            return;
        var entitiesWithDomainEvents = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
            .Where(entry => entry.Entity.DomainEvents.Any())
            .Select(entry => entry.Entity)
            .ToList();
        var domainEvents = entitiesWithDomainEvents.SelectMany(entry => entry.DomainEvents).ToList();
        entitiesWithDomainEvents.ForEach(entry => entry.ClearDomainEvents());
        foreach (var domainEvent in domainEvents) {
            await _mediator.Publish(domainEvent);
        }
    }
}