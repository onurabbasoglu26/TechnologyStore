using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TechnologyStore.Models;
using TechnologyStore.Repositories;

namespace TechnologyStore.Controllers
{
    public class ProductController : Controller
    {
        readonly CategoryRepository categoryRepository = new CategoryRepository();
        ProductRepository productRepository = new ProductRepository();
        public IActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(productRepository.GetAll((x => x.ProductName.StartsWith(p)), "Category"));
            }
            return View(productRepository.GetAll("Category"));
        }

        [HttpGet]
        public IActionResult ProductAdd()
        {
            List<SelectListItem> list = (from item in categoryRepository.GetAll()
                                         select new SelectListItem
                                         {
                                             Text = item.CategoryName,
                                             Value = item.CategoryID.ToString()
                                         }).ToList();
            ViewBag.v1 = list;
            return View();
        }

        [HttpPost]
        public IActionResult ProductAdd(Product p)
        {
            if (!ModelState.IsValid)
            {
                return View("ProductAdd");
            }

            productRepository.Insert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            List<SelectListItem> list = (from item in categoryRepository.GetAll()
                                         select new SelectListItem
                                         {
                                             Text = item.CategoryName,
                                             Value = item.CategoryID.ToString()
                                         }).ToList();
            ViewBag.v1 = list;
            var x = productRepository.GetById(id);
            return View(x);
        }

        [HttpGet]
        public IActionResult ProductUpdate(int id)
        {
            List<SelectListItem> list = (from item in categoryRepository.GetAll()
                                         select new SelectListItem
                                         {
                                             Text = item.CategoryName,
                                             Value = item.CategoryID.ToString()
                                         }).ToList();
            ViewBag.v1 = list;
            var x = productRepository.GetById(id);
            return View(x);
        }

        [HttpPost]
        public IActionResult ProductUpdate(Product p)
        {
            //var x = productRepository.GetById(p.ProductID);
            //x.ProductName = p.ProductName;
            //x.ProductDescription = p.ProductDescription;
            //x.ProductPrice = p.ProductPrice;
            //x.ProductStock = p.ProductStock;
            //x.ImageURL = p.ImageURL;
            //x.CategoryID = p.CategoryID;
            productRepository.Update(p);
            return RedirectToAction("Index");
        }

        public IActionResult ProductDelete(int id)
        {
            productRepository.Delete(productRepository.GetById(id));
            return RedirectToAction("Index");

        }
    }
}
