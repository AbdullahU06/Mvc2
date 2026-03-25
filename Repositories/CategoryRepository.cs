
//burda  bir makaralar oldu yanlış ama hayılısı 
using Repositories.Contracts;
using Store.Entities.Models;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {

        }

        public Category? GetOneCategory(int id, bool trackChanges)
        {
            return FindAll(trackChanges)
                .SingleOrDefault(c => c.CategoryId == id);
        }
    }


}