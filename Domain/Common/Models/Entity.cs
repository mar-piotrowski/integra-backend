using Domain.Abstractions;
using Domain.Events;

namespace Domain.Common.Models {
    public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents, IAuditableEntity where TId : notnull {
        public TId Id { get; set; } = default!;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void ClearDomainEvents() {
            _domainEvents.Clear();
        }

        public void AddDomainEvent(IDomainEvent domainEvent) {
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent) {
            _domainEvents.Remove(domainEvent);
        }

        public static bool operator ==(Entity<TId>? first, Entity<TId>? second) =>
            first is not null && second is not null && first.Equals(second);

        public static bool operator !=(Entity<TId>? first, Entity<TId>? second) => !(first == second);

        public bool Equals(Entity<TId>? other) =>
            other is not null && Id.Equals(other.Id);

        public override bool Equals(object? obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj is not Entity<TId> entity)
                return false;
            return obj.GetType() == GetType() && Id.Equals(entity.Id);
        }

        public override int GetHashCode() =>
            Id.GetHashCode();
    }
}