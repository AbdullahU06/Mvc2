using Repositories.Contracts;
using Services.Contracts;
using Store.Entities.Models;

namespace Services
{
    public class CategoryManager : ICategoryService
    {

        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.FindAll(trackChanges);
        }

        public Category GetOneCategory(int id, bool trackChanges)
        {
            var category = _manager.Category.GetOneCategory(id, trackChanges);
            if (category == null)
                throw new KeyNotFoundException($"Category with id: {id} not found");
            return category;
        }

        public void CreateOneCategory(Category category)
        {
            _manager.Category.CreateOneCategory(category);
            _manager.Save();
        }

        public void UpdateOneCategory(int id, Category category)
        {
            var entity = GetOneCategory(id, trackChanges: true);
            entity.CategoryName = category.CategoryName;
            _manager.Save();
        }

        public void DeleteOneCategory(int id)
        {
            var entity = GetOneCategory(id, trackChanges: true);
            _manager.Category.DeleteOneCategory(entity);
            _manager.Save();
        }

    }


}