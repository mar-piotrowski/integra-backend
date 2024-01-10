using Application.Abstractions;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork {
    private readonly DatabaseContext _databaseContext;

    public UnitOfWork(DatabaseContext databaseContext) {
        _databaseContext = databaseContext;
    }

    public Task SaveChangesAsync(CancellationToken token) {
        UpdateAuditableEntities();
        return _databaseContext.SaveChangesAsync(token);
    }

    public void SaveChanges() {
        UpdateAuditableEntities();
        _databaseContext.SaveChanges();
    }

    private void UpdateAuditableEntities() {
        var entities = _databaseContext.ChangeTracker.Entries<IAuditableEntity>();
        foreach (var entityEntry in entities) {
            if (entityEntry.State == EntityState.Added)
                entityEntry.Property(property => property.CreatedDate).CurrentValue = DateTime.UtcNow;
            if (entityEntry.State == EntityState.Modified)
                entityEntry.Property(property => property.ModifiedDate).CurrentValue = DateTime.UtcNow;
        }
    }
}