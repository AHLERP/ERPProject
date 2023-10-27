using ERPProject.Entity.DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public UserController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/Kullanıcılar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<UserDTOResponse>(url + "GetUsers");
            return View(val);
        }
        [HttpGet("/Admin/Kullanıcı")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<UserDTOResponse>(url + "GetUser/" + id);
            return View(val);
        }
        [HttpPost("/Admin/KullanıcıEkle")]
        public async Task<IActionResult> Add(UserDTORequest p)
        {
            var response = await AddAsync(p, url + "AddUser");
            if (response)
            {
                return RedirectToAction("Index", "User");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/KullanıcıGüncelle")]
        public async Task<IActionResult> Update(UserDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateUser");
            if (response)
            {
                return RedirectToAction("Index", "User");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/KullanıcıSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveUser/" + id);
            if (response)
            {
                return RedirectToAction("Index", "User");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
