using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.Poco;
using ERPProject.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public DepartmentController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Admin/Departmanlar")]
        public async Task<IActionResult> Index()
        {
            var department = await GetAllAsync<DepartmentDTOResponse>(url + "GetDepartments");
            DepartmentVM departmentVM = new DepartmentVM()

            {
                Departments = department.Data,

            };
            return View(departmentVM);
        }
        [HttpGet("/Admin/Departman")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<DepartmentDTOResponse>(url + "GetDepartment/" + id);
            return View(val);
        }
        [HttpPost("/Admin/DepartmanEkle")]
        public async Task<IActionResult> Add(DepartmentDTORequest p)
        {
            var response = await AddAsync(p, url + "AddDepartment");
            if (response)
            {
                return RedirectToAction("Sirketler", "Admin");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/DepartmanGuncelle")]
        public async Task<IActionResult> Update(DepartmentDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateDepartment");
            if (response)
            {
                return RedirectToAction("Sirketler", "Admin");

            }

            return RedirectToAction("Index", "Home");

        }
        [HttpGet("/Admin/DepartmanSil/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveDepartment/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Company");
            }
            return RedirectToAction("Index", "Home");

        }
    }
}
