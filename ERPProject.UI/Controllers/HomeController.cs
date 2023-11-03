using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
