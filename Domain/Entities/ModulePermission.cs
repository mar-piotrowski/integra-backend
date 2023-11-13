using Domain.Abstractions;

namespace Domain.Entities {
    public class ModulePermission : IAuditableEntity {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Access { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<SubModulePermission> SubModulePermissions { get; set; } = new();
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}