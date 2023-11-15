using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.Poco;
using ERPProject.UI.Areas.User.Models;
using ERPProject.UI.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class DepartmentController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public DepartmentController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Kullanici/Departmanlar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<DepartmentDTOResponse>(url + "GetDepartments");
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
        [HttpGet("/Kullanici/Departman")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<DepartmentDTOResponse>(url + "GetDepartment/" + id);
            return View(val);
        }
        [HttpPost("/Kullanici/DepartmanEkle")]
        public async Task<IActionResult> Add(DepartmentDTORequest p)
        {
            var val = await AddAsync(p, url + "AddDepartment");
            if (val.Data != null)
            {
                return RedirectToAction("Sirketler", "User");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Kullanici/DepartmanGuncelle")]
        public async Task<IActionResult> Update(DepartmentDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateDepartment");
            if (val)
            {
                return RedirectToAction("Sirketler", "User");

            }

            return RedirectToAction("Index", "Home");

        }
        [HttpGet("/Kullanici/DepartmanSil/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url + "RemoveDepartment/" + id);
            if (val)
            {
                return RedirectToAction("Index", "Company");
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
