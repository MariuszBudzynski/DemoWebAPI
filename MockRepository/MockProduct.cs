using DemoApps.Models;
using DemoApps.Repositories;

namespace DemoApps.MockRepository
{

    public class MockProduct // : IProductRepository disabled ans the mock Interface implements diffrent methods
    {

        new List<Product> products = new()
        {
            new Product
                    {
                        ProductId = "WZ100",
                        ProductName = "Cereal Bread",
                        CategoryId = new MockCategory().GetAllCategories.ToList()[0].CategoryId,
                        UnitPrice = 4m,
                        UnitsInStock = 20
                    },
                    new Product
                    {
                        ProductId = "WZ200",
                        ProductName = "Cola",
                        CategoryId = new MockCategory().GetAllCategories.ToList()[1].CategoryId,
                        UnitPrice = 8m,
                        UnitsInStock = 10
                    },
                    new Product
                    {
                        ProductId = "WZ300",
                        ProductName = "Instant soup",
                        CategoryId = new MockCategory().GetAllCategories.ToList()[2].CategoryId,
                        UnitPrice = 3m,
                        UnitsInStock = 50
                    },
                    new Product
                    {
                        ProductId = "WZ400",
                        ProductName = "Wheat roll",
                        CategoryId = new MockCategory().GetAllCategories.ToList()[0].CategoryId,
                        UnitPrice = 1m,
                        UnitsInStock = 15
                    },
                    new Product
                    {
                        ProductId = "WZ500",
                        ProductName = "Instant puree",
                        CategoryId = new MockCategory().GetAllCategories.ToList()[2].CategoryId,
                        UnitPrice = 10m,
                        UnitsInStock = 35
                    }

        };

        public IEnumerable<Product> GetAllProducts => products;

        public Product GetProductById(string id)
        {
            var result = products.Where(p => p.ProductId == id).FirstOrDefault();
            return result;
        }

        public void RemoveProductByIdMockOnly(string id)
        {
            var listSearch = products.FirstOrDefault(p => p.ProductId == id);
            if (listSearch != null) 
            {
                products.Remove(listSearch);
            }
        }

        public bool AddProductdMockOnly(List<Product> pr)
        {
            var tempList = products;
            var elemntNumbers = 0;

            for (int i = 0; i < pr.Count; i++)
            {
                var contains = from tempP in tempList
                               where tempP.ProductId == pr[i].ProductId
                               select tempP.ProductId;

                if (!contains.Any())
                {
                    products.Add(pr[i]);
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
                var contains = products.Where(p => p.ProductId == lp[i].ProductId).FirstOrDefault();

                if (contains is not null)
                {
                   
                    products.Remove(contains);
                    products.Add(lp[i]);
                    elemntNumbers++;
                }
            }

            if (elemntNumbers > 0)
            {
                //products.AddRange(tempList);
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
