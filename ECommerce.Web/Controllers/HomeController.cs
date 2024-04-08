using ECommerce.ENTITIES.Models;
using ECommerce.Web.Models;
using ECommerce.Web.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CategoryService categoryService = new CategoryService();
            var categories = categoryService.GetAll();
            return View(categories);
        }

        public IActionResult Products(int categoryId)
        {
            ProductService productService = new ProductService();
            var products = productService.GetAllCategoryProduct(categoryId);
            return PartialView("_Products",products);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
