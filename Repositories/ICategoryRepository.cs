using DemoApps.Models;

namespace DemoApps.Repositories
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategories { get;}
        public Category GetCategoryById(string id);
    }
}
