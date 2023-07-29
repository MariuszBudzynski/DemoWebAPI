using DemoApps.Models;

namespace DemoApps.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts { get; }
        public Product GetProductById(string id);
        public bool RemoveProductByI(string id);
        public bool AddProductds(List<Product> pr);
        public bool UpdateProductsMockOnly(List<Product> lp);

    }
}
