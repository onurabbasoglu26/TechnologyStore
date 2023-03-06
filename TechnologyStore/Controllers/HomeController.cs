using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnologyStore.Repositories;

namespace TechnologyStore.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        readonly ProductRepository productRepository = new ProductRepository();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Laptop()
        {
            var products = productRepository.GetAll();
            return View(products);
        }
    }
}
