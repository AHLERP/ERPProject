using ERPProject.Entity.DTO.RoleDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public RoleController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/Roller")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<RoleDTOResponse>(url + "Roles");
            return View(val);
        }
        [HttpGet("/Admin/Rol")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<RoleDTOResponse>(url + "GetRole/" + id);
            return View(val);
        }
        [HttpPost("/Admin/RolEkle")]
        public async Task<IActionResult> Add(RoleDTORequest p)
        {
            var response = await AddAsync(p, url + "AddRole");
            if (response)
            {
                return RedirectToAction("Index", "Role");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/RolGuncelle")]
        public async Task<IActionResult> Update(RoleDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateRole");
            if (response)
            {
                return RedirectToAction("Index", "Role");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet("/Admin/RolSil/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveRole/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Role");
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
