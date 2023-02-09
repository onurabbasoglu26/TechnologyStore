using Microsoft.AspNetCore.Mvc;
using TechnologyStore.Models;
using TechnologyStore.Repositories;

namespace TechnologyStore.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository repository = new CategoryRepository();
        public IActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(repository.GetAll(x => x.CategoryName.StartsWith(p)));
            }
            return View(repository.GetAll());
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }

            repository.Insert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CategoryDetails(int id)
        {
            var x = repository.GetById(id);
            return View(x);
        }

        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var x = repository.GetById(id);
            return View(x);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            //var x = repository.GetById(p.CategoryID);
            //x.CategoryName = p.CategoryName;
            //x.CategoryDescription = p.CategoryDescription;
            //x.Status = true;
            p.Status = true;
            repository.Update(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CategoryDelete(int id)
        {
            var x = repository.GetById(id);
            x.Status = false;
            repository.Update(x);
            return RedirectToAction("Index");
        }
    }
}
