using Entities.Models;
using Store.Entities.Models;

namespace Repositories.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Category? GetOneCategory(int id, bool trackChanges);
        void CreateOneCategory(Category category);
        void UpdateOneCategory(Category category);
        void DeleteOneCategory(Category category);
    }
}
