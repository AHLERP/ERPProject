using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Unauthorized()
        {
            return View();
        }
        public IActionResult Forbidden()
        {
            return View();
        }
        public IActionResult SifreSifirlama()
        {
            return View();
        }
    }
}
