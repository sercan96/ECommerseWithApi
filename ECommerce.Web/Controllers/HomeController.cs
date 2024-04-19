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
            CategoryService categoryService = new CategoryService("http://localhost:5251");
            var categories = categoryService.GetAll();
            return View(categories);
        }

        public IActionResult Products(int categoryId)
        {
            ProductService productService = new ProductService("http://localhost:5251");
            var products = productService.GetAllCategoryProduct(categoryId);
            return PartialView("_Products",products);
        }

        /*
         * Partial View:
         * K�smi g�r�n�mler, kod tekrar�n� azalt�r, bak�m� kolayla�t�r�r ve yeniden kullan�labilirli�i art�r�r. Bu nedenle, belirli bir b�lgenin ayr� bir bile�en olarak tan�mlanmas� gerekti�inde, Partial View'lerin kullan�lmas� yayg�n bir uygulamad�r.
        */


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
