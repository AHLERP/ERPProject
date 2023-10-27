using ERPProject.Entity.DTO.UserRoleDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    public class UserRoleController : BaseController
    {
        private readonly string url = "";
        public UserRoleController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<UserRoleDTOResponse>(url);
            return View(val);
        }
        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<UserRoleDTOResponse>(url + id);
            return View(val);
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserRoleDTORequest p)
        {
            var response = await AddAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "UserRole");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Update(UserRoleDTORequest p)
        {
            var response = await UpdateAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "UserRole");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + id);
            if (response)
            {
                return RedirectToAction("Index", "UserRole");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
