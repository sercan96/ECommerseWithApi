using ECommerce.DAL.ContextClasses;
using ECommerce.ENTITIES.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerse.WebApi.Controllers
{
    [ApiController] // Indicates that it is an API controller.
    [Route("Api/[controller]")] //A path prefix is defined using the controller name. For example, if a controller name is "ProductsController", this attribute maps the Api/Products path
    public class ProductController : Controller
    {
        Context _db;
        private readonly ILogger<ProductController> _logger; // debugging and monitoring
        public ProductController(ILogger<ProductController> logger, Context db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _db.Products.FirstOrDefaultAsync(i => i.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("all", Name = "GetAllProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var p = await _db.Products.ToListAsync();
            return Ok(p);
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<IActionResult> Add(Product product)
        {
            try
            {
                if (product == null || product.CategoryId <= 0)
                {
                    return BadRequest("Invalid product information.");
                }

                _db.Products.Add(product);
                await _db.SaveChangesAsync();

                return Ok("The product has been added successfully.");
            }
            catch (Exception ex)
            {
                // Loglama yapılabilir
                return StatusCode(500, "Something went wrong.");
            }
        }

        [HttpDelete(Name = "DeleteProduct")]
        public void Delete(int productId)
        {
            var product = _db.Products.FirstOrDefault(c => c.ID == productId);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        [HttpGet("category/{categoryId}", Name = "GetProductCategory")]
        public IEnumerable<Product> GetProductCategory(int categoryId)
        {
            _logger.LogInformation("Product information was retrieved according to category");
            return _db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product entity)
        {
            if (id != entity.ID)
            {
                return BadRequest();
            }

            var product = await _db.Products.FirstOrDefaultAsync(i => i.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = entity.ProductName;
            product.UnitPrice = entity.UnitPrice;
            product.CategoryId = entity.CategoryId;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return NoContent();

        }
    }
}
