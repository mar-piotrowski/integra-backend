using Application.Dtos;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IPermissionRepository : IRepository<Permission, PermissionId> {
   public IEnumerable<Permission> GetAll(PermissionQueryParams filters);
   public Permission? GetByCode(PermissionCode code);
   public Permission? GetByName(string name);
   public List<Permission> GetByCodes(List<PermissionCode> codes);
   public List<Permission> GetManagementPermissions();
}