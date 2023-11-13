using Domain.Events;
using MediatR;

namespace Application.Features.Order.Events; 

public class DummyHandler : INotificationHandler<OrderCreated> {
    public Task Handle(OrderCreated notification, CancellationToken cancellationToken) {
        return Task.CompletedTask;
    }
}