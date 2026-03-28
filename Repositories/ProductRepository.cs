using Entities.RequestParameters;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Entities.Product>, Contracts.IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Entities.Product> GetAllProducts(bool trackChanges) =>
            FindAll(trackChanges);

        public IQueryable<Entities.Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return FindAll(false)
                .Where(x => !p.CategoryId.HasValue || x.CategoryId.Equals(p.CategoryId))
                .Where(x => x.Price >= p.MinPrice && x.Price <= p.MaxPrice)
                .Where(x => string.IsNullOrWhiteSpace(p.SearchTerm) || x.ProductName.ToLower().Contains(p.SearchTerm.ToLower()));
        }

        public Entities.Product? GetOneProduct(int id, bool trackChanges) =>
            FindAll(trackChanges).SingleOrDefault(p => p.ProductId == id);

        public void CreateOneProduct(Entities.Product product) => Create(product);
        public void UpdateOneProduct(Entities.Product product) => Update(product);
        public void DeleteOneProduct(Entities.Product product) => Remove(product);
    }

}