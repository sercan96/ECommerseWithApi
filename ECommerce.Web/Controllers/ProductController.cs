using ECommerce.DAL.ContextClasses;
using ECommerce.ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;
using ECommerce.BLL.Managers.Concretes;
using ECommerce.BLL.Managers.Abstracts;

namespace ECommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        Context _db;
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            _productManager.Add(product);
            //_productManager.Save();
            return RedirectToAction("List");

        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(_productManager.GetAll());
        }
    }
}
