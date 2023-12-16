using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Domain.ValueObjects {
    public class ModulePermission : ValueObject {
        public ModulePermissionType Type { get; private set; }

        public ModulePermission(ModulePermissionType type) {
            Type = type;
        }
        
        protected override IEnumerable<object> GetAtomicValues() {
            yield return Type;
        }
    }
}