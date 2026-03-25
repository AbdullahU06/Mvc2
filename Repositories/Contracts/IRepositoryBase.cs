namespace Repositories.Contracts;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    void Create(T entity);
    void Update(T entity);
    void Remove(T entity);

}