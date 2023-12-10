using Application.Abstractions.Repositories;
using Domain.Common.Models;

namespace Infrastructure.Repositories;

public abstract class Repository<TEntity, TIdentityEntity> : IRepository<TEntity, TIdentityEntity>
    where TEntity : Entity<TIdentityEntity>
    where TIdentityEntity : class {
    protected readonly DatabaseContext DbContext;

    protected Repository(DatabaseContext dbContext) =>
        DbContext = dbContext;

    public virtual IEnumerable<TEntity> GetAll() =>
        DbContext.Set<TEntity>().ToList();

    public virtual TEntity? GetById(TIdentityEntity id) =>
        DbContext.Set<TEntity>().FirstOrDefault(entity => entity.Id == id);

    public virtual void Add(TEntity entity) =>
        DbContext.Set<TEntity>().Add(entity);

    public virtual void AddRange(IEnumerable<TEntity> entities) =>
        DbContext.Set<TEntity>().AddRange(entities);

    public virtual void Update(TEntity entity) =>
        DbContext.Set<TEntity>().Update(entity);

    public virtual void UpdateRange(IEnumerable<TEntity> entities) =>
        DbContext.Set<TEntity>().UpdateRange(entities);

    public virtual void Remove(TEntity entity) =>
        DbContext.Set<TEntity>().Remove(entity);

    public virtual void RemoveRange(IEnumerable<TEntity> entities) =>
        DbContext.Set<TEntity>().RemoveRange(entities);
}