using Entities;
using Entities.RequestParameters;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        Product? GetOneProduct(int id, bool trackChanges);
        void CreateOneProduct(Product product);
        void UpdateOneProduct(Product product);
        void DeleteOneProduct(Product product);
    }
}