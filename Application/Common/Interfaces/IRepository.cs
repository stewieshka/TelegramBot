namespace Application.Common.Interfaces;

public interface IRepository<TEntity>
{
    public Task<TEntity?> GetById(Guid id);

    public Task<List<TEntity>> Get(int limit);

    public Task<TEntity> Add(TEntity entity);

    public TEntity? Update(TEntity entity);

    public bool Delete(Guid id);
}