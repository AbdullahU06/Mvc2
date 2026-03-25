using Store.Entities.Models;

namespace Repositories.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Category GetOneCategory(int id, bool trackChanges);
    }
}
