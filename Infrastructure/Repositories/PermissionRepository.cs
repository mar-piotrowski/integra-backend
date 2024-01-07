using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Infrastructure.Repositories;

public class PermissionRepository : Repository<Permission, PermissionId>, IPermissionRepository {
    public PermissionRepository(DatabaseContext dbContext) : base(dbContext) { }

    public IEnumerable<Permission> GetAll(PermissionQueryParams filters) {
        IQueryable<Permission> queryable = DbContext.Set<Permission>();
        if (filters.Type is not null)
            queryable = queryable.Where(entry => entry.Type == filters.Type);
        return queryable.ToList();
    }

    public Permission? GetByCode(PermissionCode code) =>
        DbContext.Set<Permission>().FirstOrDefault(entry => entry.Code == code);

    public Permission? GetByName(string name) =>
        DbContext.Set<Permission>().FirstOrDefault(entry => entry.Name == name);
}