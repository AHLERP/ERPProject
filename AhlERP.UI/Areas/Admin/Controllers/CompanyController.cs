using ERPProject.Entity.DTO.CompanyDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : BaseController
    {
        string url = "";
        public CompanyController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
        [HttpGet("/Sirketler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<CompanyDTOResponse>(url);
            return View(val);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CompanyDTORequest p)   
        {
            var val = await AddAsync(p,url);
            return View(val);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CompanyDTORequest p)
        {
            var val = await UpdateAsync(p, url);
            return View(val);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url,id);
            return View(val);
        }

    }
}
