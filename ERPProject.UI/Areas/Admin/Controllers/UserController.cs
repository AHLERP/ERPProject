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
        public UserController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/Kullanicilar")]
        public async Task<IActionResult> Index()
        {
            var users = await GetAllAsync<UserDTOResponse>(url + "GetUsers");
            var departments = await GetAllAsync<DepartmentDTOResponse>(url + "GetDepartments");
            var roles = await GetAllAsync<RoleDTOResponse>(url + "Roles");
            var requests = await GetAllAsync<RequestDTOResponse>(url + "GetRequests");
            var compaines = await GetAllAsync<CompanyDTOResponse>(url + "GetCompanies");

            UserVM userVM = new UserVM
            {
                Departments = departments,
                Users = users,
                Roles = roles,
                Requests = requests,
                Companies= compaines
                
            };

            return View(userVM);
        }
        [HttpGet("/Admin/Kullanici")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<UserDTOResponse>(url + "GetUser/" + id);
            return View(val);
        }
        [HttpPost("/Admin/KullaniciEkle")]
        public async Task<IActionResult> Add(UserDTORequest p)
        {
            var response = await AddAsync(p, url + "AddUser");
            if (response)
            {
                return RedirectToAction("Index", "User");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/KullaniciGuncelle")]
        public async Task<IActionResult> Update(UserDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateUser");
            if (response)
            {
                return RedirectToAction("Kullanicilar", "Admin");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet("/Admin/KullaniciSil/{id}")]
        public async Task<IActionResult> Delete(Int64 id)
        {
            var response = await DeleteAsync(url + "RemoveUser/" + id);
            if (response)
            {
                return RedirectToAction("Kullanicilar", "Admin");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
