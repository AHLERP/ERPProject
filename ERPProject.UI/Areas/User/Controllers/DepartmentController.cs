using ERPProject.Entity.DTO.DepartmentDTO;
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
        [HttpGet("/User/Departmanlar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<DepartmentDTOResponse>(url + "GetDepartments");
            return View(val);
        }
        [HttpGet("/User/Departman")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<DepartmentDTOResponse>(url + "GetDepartment/" + id);
            return View(val);
        }
        [HttpPost("/User/DepartmanEkle")]
        public async Task<IActionResult> Add(DepartmentDTORequest p)
        {
            var response = await AddAsync(p, url + "AddDepartment");
            if (response)
            {
                return RedirectToAction("Index", "Department");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/DepartmanGuncelle")]
        public async Task<IActionResult> Update(DepartmentDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateDepartment");
            if (response)
            {
                return RedirectToAction("Index", "Department");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/DepartmanSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveDepartment/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Department");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
