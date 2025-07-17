using WebAPIModel.Repositories;
using WebAPIModel.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        public ProductController()
        {
            // Using the concrete implementation of IProductRepo
            _productRepo = new ProductRepo();
        }
        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _productRepo.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("getById/{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productRepo.GetProduct(id);
            if (product == null)
            {
                return NotFound("Invalid Id");// Return 404 if product not found
            }
            return Ok(product);// Return 200 with product details
        }
        [HttpPost("add")]
        public ActionResult AddProduct(Product product)
        {
            //instead of id we can use Guid.NewGuid() to generate a unique identifier
            _productRepo.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Invalid data");
            }
            _productRepo.UpdateProduct(product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            _productRepo.DeleteProduct(id);
            return NoContent();// Return 204 No Content if deletion is successful
        }
    }
}
