using Domain.Common.Models;

namespace Domain.Events;

public interface IHasDomainEvents {
    public IReadOnlyList<IDomainEvent> DomainEvents { get; }
    public void ClearDomainEvents();
}