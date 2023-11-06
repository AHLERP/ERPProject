using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.DTO.RoleDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public UserController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Admin/Kullanicilar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<UserDTOResponse>(url + "GetUsers");
            var val2 = await GetAllAsync<DepartmentDTOResponse>(url + "GetDepartments");
            var val3 = await GetAllAsync<RoleDTOResponse>(url + "Roles");
            var val4 = await GetAllAsync<RequestDTOResponse>(url + "GetRequests");

            UserVM userVM = new UserVM
            {
                Departments = val2.Data,
                Users = val.Data,
                Roles = val3.Data,
                Requests = val4.Data
            };

            return View(userVM);
        }
        [HttpGet("/Admin/Kullanici")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<UserDTOResponse>(url + "GetUser/" + id);
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            return View(val);
        }
        [HttpPost("/Admin/KullaniciEkle")]
        public async Task<IActionResult> Add(UserDTORequest p)
        {
            var val = await AddAsync(p, url + "AddUser");
            if (val)
            {
                return RedirectToAction("Index", "User");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/KullaniciGuncelle")]
        public async Task<IActionResult> Update(UserDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateUser");
            if (val)
            {
                return RedirectToAction("Kullanicilar", "Admin");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet("/Admin/KullaniciSil/{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            var val = await DeleteAsync(url + "RemoveUser/" + id);
            if (val)
            {
                return RedirectToAction("Kullanicilar", "Admin");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
