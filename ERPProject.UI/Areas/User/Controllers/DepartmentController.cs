using ERPProject.Entity.DTO.DepartmentDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    public class DepartmentController : BaseController
    {
        private readonly string url = "";
        public DepartmentController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<DepartmentDTOResponse>(url);
            return View(val);
        }
        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<DepartmentDTOResponse>(url + id);
            return View(val);
        }
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentDTORequest p)
        {
            var response = await AddAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "Department");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentDTORequest p)
        {
            var response = await UpdateAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "Department");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + id);
            if (response)
            {
                return RedirectToAction("Index", "Department");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
