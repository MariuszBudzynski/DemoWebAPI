using DemoApps.Models;
using DemoApps.Repositories;
using System.Collections.Generic;

namespace DemoApps.MockRepository
{
    public class MockCategory : ICategoryRepository
    {
        private List<Category> categories = new()
        {
            new Category
            {
                CategoryId = "AZ100",
                CategoryName = "Bread",
                Description = "Baked goods made of flour, water and salt combined with various additives."
            },
            new Category
            {
                CategoryId = "AZ200",
                CategoryName = "Alkohol free drinks",
                Description = "A type of beverage that does not contain significant amounts of alcohol."
            },
            new Category
            {
                CategoryId = "AZ300",
                CategoryName = "Instant dishes",
                Description = "Instant product that is ready in a few minutes after pouring boiling water or other liquid.."
            }};
        public IEnumerable<Category> GetAllCategories => categories;

        public Category GetCategoryById(string id)
        {
           var result = categories.Where(c => c.CategoryId == id).FirstOrDefault();
           return result;
            
        }
    }
}
