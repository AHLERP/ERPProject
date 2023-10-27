using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.DepartmentDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    public class DepartmentController : BaseController
    {
        string url = "";

        public DepartmentController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        [HttpGet("/Sirketler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<DepartmentDTOResponse>(url);
            return View(val);
        }
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentDTORequest p)
        {
            var val = await AddAsync(p, url);
            return View(val);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentDTORequest p)
        {
            var val = await UpdateAsync(p, url);
            return View(val);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url, id);
            return View(val);
        }
    }
}
