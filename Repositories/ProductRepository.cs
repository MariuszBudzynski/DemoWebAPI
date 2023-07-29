using DemoApps.Models;
using DemoApps.Repositories;
using Microsoft.IdentityModel.Tokens;
using WebAPIdemo.Models;

namespace WebAPIdemo.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly WebAPIdbContext db;

        public ProductRepository(WebAPIdbContext _db)
        {
            db = _db;
        }
        public IEnumerable<Product> GetAllProducts {
            get
            {
                IQueryable<Product> products = db.Products;
                return products.ToList();
            } }
        
        public Product GetProductById(string id)
        {
            IQueryable<Product> query = (db.Products.Where(c => c.ProductId == id));
            var result = query.FirstOrDefault();
            return result;
        }

        public bool RemoveProductByI(string id)
        {
            IQueryable<Product> query = db.Products.Where(p => p.ProductId == id);
            var listSearch = (query.ToList()).FirstOrDefault();

            if (listSearch != null)
            {
                db.Products.Remove(listSearch);
                db.SaveChanges();
                return true;
            }
            else { return false; }
            
        }

        public bool AddProductds(List<Product> pr)
        {
            var elemntNumbers = 0;

            foreach (var p in pr)
            {
                IQueryable<string> idSearch = from i in db.Products
                                             where i.ProductId == p.ProductId
                                             select i.ProductId;
                    
                    
                    //db.Products.Select(q => q.ProductId == p.ProductId);

                if (idSearch.IsNullOrEmpty())
                {
                    db.Products.Add(p);
                    db.SaveChanges();
                    elemntNumbers++;
                }

            }

            if (elemntNumbers > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProductsMockOnly(List<Product> lp)
        {
            var elemntNumbers = 0;

            for (int i = 0; i < lp.Count; i++)
            {
                IQueryable<string> idSearch = db.Products.Where(p => p.ProductId == lp[i].ProductId).Select(p=>p.ProductId);

                if (!idSearch.IsNullOrEmpty())
                {
                    db.Update(lp[i]);
                    db.SaveChanges();
                    elemntNumbers++;
                }
            }

            if (elemntNumbers > 0)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }








    }
}
