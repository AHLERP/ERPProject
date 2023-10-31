using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Account.Controller
{
    [Area("Account")]
    public class AccountController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public AccountController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
