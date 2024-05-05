namespace Application.Common.Interfaces;

public interface IRepository<TEntity>
{
    public TEntity? GetById(Guid id);

    public TEntity Add(TEntity entity);

    public TEntity? Update(TEntity entity);

    public bool Delete(Guid id);
}