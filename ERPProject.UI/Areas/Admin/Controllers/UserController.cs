using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "url yazılacak";
        #endregion
        #region Constructor
        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion
        [HttpGet("/Admin/Kullanicilar")]
        public async Task<IActionResult> Index()
        {

            return View();
        }
    }
}
