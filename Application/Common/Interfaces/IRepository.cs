namespace Application.Common.Interfaces;

public interface IRepository<TEntity>
{
    public Task<TEntity?> GetById(Guid id);

    public Task<List<TEntity>> Get(int limit);

    public Task<TEntity> Add(TEntity entity);

    public bool Delete(TEntity entity);

    public Task SaveChangesAsync();
}