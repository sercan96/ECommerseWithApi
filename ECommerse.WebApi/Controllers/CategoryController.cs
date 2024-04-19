using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ECommerce.ENTITIES.Models;
using ECommerce.DAL.ContextClasses;
using Microsoft.EntityFrameworkCore;

namespace ECommerse.WebApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class CategoryController : ControllerBase // We dont get View
    {
        Context _db;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ILogger<CategoryController> logger, Context db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet("{categoryId}", Name = "GetCategory")]
        public async Task<IActionResult> Get(int? categoryId) // async => return void,Task,Task<T> 
        {
            if (categoryId == null)
            {
                return NotFound();
            }

            // Works like synchronous, waits for the operation to be completed
            var category =  await _db.Categories.FirstOrDefaultAsync(x => x.ID == categoryId);
 
            if (category == null)
            {
                return NotFound(); // 404
            }

            return Ok(category);
        }

         [HttpGet("all", Name = "GetAllCategories")]
        public IEnumerable<Category> GetAll()
        {
            var list = _db.Categories.ToList();
            return list;
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<IActionResult> Add(Category category)
        {
            try
            {   
               _db.Categories.Add(category);
                await _db.SaveChangesAsync();

                return Ok("The category has been added successfully.");
            }
            catch (Exception ex)
            {
                // Log
                return StatusCode(500, "Something went wrong.");
            }
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
