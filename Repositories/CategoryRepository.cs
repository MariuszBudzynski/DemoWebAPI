using DemoApps.Models;
using DemoApps.Repositories;
using WebAPIdemo.Models;

namespace WebAPIdemo.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WebAPIdbContext db;

        public CategoryRepository(WebAPIdbContext _db)
        {
            db = _db;
        }
        public IEnumerable<Category> GetAllCategories
        {
            get
            {
                IQueryable<Category> categories = db.Categories;
                return categories.ToList();
            }
        }

        public Category GetCategoryById(string id)
        {
            IQueryable<Category> query = (db.Categories.Where(c => c.CategoryId == id));
            var result = query.FirstOrDefault();
            return result;
        }
    }
}
