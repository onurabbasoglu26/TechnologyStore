using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TechnologyStore.Repositories;

namespace TechnologyStore.Controllers
{
    public class StatisticController : Controller
    {
        readonly CategoryRepository categoryRepository = new CategoryRepository();
        readonly ProductRepository productRepository = new ProductRepository();

        public IActionResult Index()
        {
            var value1 = categoryRepository.GetAll().Count();
            ViewBag.v1 = value1;

            var value2 = productRepository.GetAll().Count();
            ViewBag.v2 = value2;

            var value3 = productRepository.GetAll("Category").Where(x => x.Category.CategoryName == "Computer").Count();
            ViewBag.v3 = value3;

            var value4 = productRepository.GetAll("Category").Where(x => x.Category.CategoryName == "Computer").Sum(x => x.ProductStock);
            ViewBag.v4 = value4;

            var value5 = productRepository.GetAll().OrderByDescending(x => x.ProductStock).FirstOrDefault().ProductName;
            ViewBag.v5 = value5;

            var value6 = productRepository.GetAll().OrderBy(x => x.ProductStock).FirstOrDefault().ProductName;
            ViewBag.v6 = value6;

            var value7 = productRepository.GetAll("Category").Where(x => x.Category.CategoryName == "Computer").Average(x => x.ProductPrice).ToString("0.00");
            ViewBag.v7 = value7;

            var value8 = productRepository.GetAll("Category").Where(x => x.Category.CategoryName == "Computer").OrderByDescending(x => x.ProductPrice).FirstOrDefault().ProductName;
            ViewBag.v8 = value8;

            return View();
        }
    }
}
