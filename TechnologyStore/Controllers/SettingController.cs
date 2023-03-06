using Microsoft.AspNetCore.Mvc;
using TechnologyStore.Repositories;

namespace TechnologyStore.Controllers
{
    public class SettingController : Controller
    {
        AdminRepository adminRepository = new AdminRepository();

        public IActionResult Index()
        {
            var admin = adminRepository.GetAll();
            return View(admin);
        }
    }
}
