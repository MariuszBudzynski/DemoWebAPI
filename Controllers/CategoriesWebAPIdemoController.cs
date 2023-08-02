using DemoApps.MockRepository;
using DemoApps.Models;
using DemoApps.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesWebAPIdemoController : ControllerBase
    {
        private readonly ICategoryRepository _category;

        public CategoriesWebAPIdemoController(ICategoryRepository category)
        {
            _category = category;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await Task.FromResult(_category.GetAllCategories);
            return categories;
        }


        [HttpGet("GetSingleCategory/{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSingleCategory(string id)
        {
            var singleCategory = await Task.FromResult(_category.GetCategoryById(id));
            if (singleCategory is null)
            {
                return NotFound("Item not found");
            }
            else
            {
                return Ok(singleCategory);
            }
        }

    }
}
