using DemoApps.MockRepository;
using DemoApps.Models;
using DemoApps.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsWebAPIdemoController : ControllerBase
    {
        private readonly IProductRepository _product;
        MockProduct mockProduct = new MockProduct(); //for Mock  REMOVE/UPDATE/ADD purpose only also it can be used for product
                                                     //reading as the interface implemnts diffrent live methods

        public ProductsWebAPIdemoController(IProductRepository product)
        {
            _product = product;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await Task.FromResult(_product.GetAllProducts);
            return products;
        }

        [HttpGet("GetSingleProduct/{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetSingleProduct(string id)
        {
            var singleProduct = await Task.FromResult(_product.GetProductById(id));
            if (singleProduct is null)
            {
                return NotFound("Product");
            }
            else
            {
                return Ok(singleProduct);
            }
        }

        [HttpDelete("RemoveProductById/{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveProductById(string id)
        {

            var productCheck = await Task.FromResult(_product.RemoveProductByI(id));
            if (!productCheck)
            {
                return BadRequest("Product was not found");
            }
            else
            {
                mockProduct.RemoveProductByIdMockOnly(id);
                return NoContent();
            }
        }

        [HttpPost("AddProducts")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddAddProducts([FromBody] List<Product> pr)
        {

            var productsAdded = await Task.FromResult(_product.AddProductds(pr));

            if (!productsAdded)
            {
                return BadRequest("Passed products were already added");
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPut("UpdateProducts")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateProductsMockOnly([FromBody] List<Product> pr)
        {

            var productsAdded = await Task.FromResult(_product.UpdateProductsMockOnly(pr));

            if (productsAdded)
            {
                return NoContent();

            }
            else
            {
                return BadRequest("No products were updated");
            }
        }

        // Mock data operations 
        // These  will not use DI container
        [HttpDelete("Mock/RemoveProductByIdMockOnly/{id}")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveProductByIdMockOnly(string id)
        {

            var productCheck = await Task.FromResult(mockProduct.GetProductById(id));
            if (productCheck is null)
            {
                return BadRequest("Product was not found");
            }
            else
            {
                mockProduct.RemoveProductByIdMockOnly(id);
                return NoContent();
            }
        }

        [HttpPost("Mock/AddProductdMockOnly")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddProductdMockOnly([FromBody] List<Product> pr)
        {

            var productsAdded = await Task.FromResult(mockProduct.AddProductdMockOnly(pr));

            if (!productsAdded)
            {
                return BadRequest("Passed products were already added");
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("Mock/UpdateProductdMockOnly")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateProductdMockOnly([FromBody] List<Product> pr)
        {

            var productsAdded = await Task.FromResult(mockProduct.UpdateProductsMockOnly(pr));

            if (productsAdded)
            {
                //return NoContent();
                return Ok(mockProduct);
            }
            else
            {
                return BadRequest("No products were updated");
            }
        }
    }
}
