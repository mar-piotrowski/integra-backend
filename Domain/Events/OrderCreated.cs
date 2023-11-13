using Domain.Common.Models;
using Domain.Entities;

namespace Domain.Events {
    public record OrderCreated(Order Order) : IDomainEvent;
}