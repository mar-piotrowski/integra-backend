namespace Domain.Abstractions {
    public interface IAuditableEntity {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}