using ECommerce.DAL.ContextClasses;
using ECommerce.ENTITIES.Models;

using Microsoft.AspNetCore.Mvc;

namespace ECommerse.WebApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProductController : Controller
    {
        Context _db;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger, Context db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet("{productId}", Name = "GetProduct")]
        public Product Get(int productId)
        {
            _logger.LogInformation("Urun bilgisi cekildi");
            return _db.Products.FirstOrDefault(x => x.ID == productId);
        }

        [HttpGet("all", Name = "GetAllProducts")]
        public IEnumerable<Product> GetAll()
        {
            var list = _db.Products.ToList();
            return list;
        }

        [HttpPost(Name = "AddProduct")]
        public void Add(Product product)
        {
            //If the product to be added has any category then add it
            if (product.CategoryId > 0)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
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
            _logger.LogInformation("Categoriye göre Urun bilgisi cekildi");
            return _db.Products.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
