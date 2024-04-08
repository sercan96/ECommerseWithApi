using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ECommerce.BLL.Managers.Concretes;
using ECommerce.ENTITIES.Models;
using ECommerce.BLL.Managers.Abstracts;
using ECommerce.DAL.ContextClasses;

namespace ECommerse.WebApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CategoryController : ControllerBase
    {
        Context _db;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ILogger<CategoryController> logger, Context db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet("{categoryId}", Name = "GetCategory")]
        public Category Get(int categoryId)
        {
            return _db.Categories.FirstOrDefault(x => x.ID == categoryId);
        }

         [HttpGet("all", Name = "GetAllCategories")]
        public IEnumerable<Category> GetAll()
        {
            var list = _db.Categories.ToList();
            return list;
        }

        [HttpPost(Name = "AddCategory")]
        public void Add(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        [HttpDelete(Name = "DeleteCategory")]
        public void Delete(int categoryId)
        {
            if(_db.Products.Where(i=> i.CategoryId == categoryId).ToList().Count == 0)
            {
                var category = _db.Categories.FirstOrDefault(c => c.ID == categoryId);
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }            
        }

    }
}
