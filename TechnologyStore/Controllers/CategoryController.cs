using Microsoft.AspNetCore.Mvc;
using TechnologyStore.Models;
using TechnologyStore.Repositories;
using X.PagedList;

namespace TechnologyStore.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository repository = new CategoryRepository();
        public IActionResult Index(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(repository.GetAll(x => x.CategoryName.Contains(p)).ToPagedList(page, 5));
            }
            return View(repository.GetAll().ToPagedList(page, 5));
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
