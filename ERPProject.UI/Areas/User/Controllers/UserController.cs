using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.DTO.RoleDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.UI.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public UserController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Kullanici/Kullanicilar")]
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
        [HttpGet("/Kullanici/Kullanicilar")]
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
            return View(val);
        }
        [HttpPost("/Kullanici/KullaniciEkle")]
        public async Task<IActionResult> Add(UserDTORequest p)
        {
            var val = await AddAsync(p, url + "AddUser");
            if (val)
            {
                return RedirectToAction("Index", "User");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Kullanici/KullaniciGuncelle")]
        public async Task<IActionResult> Update(UserDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateUser");
            if (val)
            {
                return RedirectToAction("Kullanicilar", "User");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet("/Kullanici/KullaniciSil/{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            var val = await DeleteAsync(url + "RemoveUser/" + id);
            if (val)
            {
                return RedirectToAction("Kullanicilar", "User");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
