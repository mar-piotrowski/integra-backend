using Application.Abstractions.Repositories;
using Domain.Common.Models;

namespace Infrastructure.Repositories;

public abstract class Repository<TEntity, TIdentityEntity> : IRepository<TEntity, TIdentityEntity>
    where TEntity : Entity<TIdentityEntity>
    where TIdentityEntity : class {
    protected readonly DatabaseContext DbContext;

    protected Repository(DatabaseContext dbContext) =>
        DbContext = dbContext;

    public IEnumerable<TEntity> GetAll() =>
        DbContext.Set<TEntity>().ToList();

    public TEntity? GetById(TIdentityEntity id) =>
        DbContext.Set<TEntity>().FirstOrDefault(entity => entity.Id == id);

    public void Add(TEntity entity) =>
        DbContext.Set<TEntity>().Add(entity);

    public void AddRange(IEnumerable<TEntity> entities) =>
        DbContext.Set<TEntity>().AddRange(entities);

    public void Update(TEntity entity) =>
        DbContext.Set<TEntity>().Update(entity);

    public void UpdateRange(IEnumerable<TEntity> entities) =>
        DbContext.Set<TEntity>().UpdateRange(entities);

    public void Remove(TEntity entity) =>
        DbContext.Set<TEntity>().Remove(entity);

    public void RemoveRange(IEnumerable<TEntity> entities) =>
        DbContext.Set<TEntity>().RemoveRange(entities);
}