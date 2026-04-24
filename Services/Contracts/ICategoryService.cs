using Store.Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        Category GetOneCategory(int id, bool trackChanges);
        void CreateOneCategory(Category category);
        void UpdateOneCategory(int id, Category category);
        void DeleteOneCategory(int id);
    }
}