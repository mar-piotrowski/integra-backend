namespace Application.Abstractions.Repositories;

public interface IRepository<TEntity, in TIdentityEntity>
    where TEntity : class
    where TIdentityEntity : class {
    public IEnumerable<TEntity> GetAll();
    public TEntity? GetById(TIdentityEntity id);
    public void Add(TEntity entity);
    public void AddRange(IEnumerable<TEntity> entities);
    public void Update(TEntity entity);
    public void UpdateRange(IEnumerable<TEntity> entities);
    public void Remove(TEntity entity);
    public void RemoveRange(IEnumerable<TEntity> entities);
}