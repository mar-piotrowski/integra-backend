using Domain.Abstractions;

namespace Domain.Entities {
    public class SubModulePermission : IAuditableEntity {
        public int Id { get; set; }
        public required string Name { get; set; }
        // public required bool Access { get; set; }
        // public required int ModulePermissionId { get; set; }
        // public required ModulePermission ModulePermission { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}