using ERPProject.Entity.DTO.CompanyDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly string url = "";
        public CompanyController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }

        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<CompanyDTOResponse>(url);
            return View(val);
        }
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<CompanyDTOResponse>(url + id);
            return View(val);
        }
        public async Task<IActionResult> Add(CompanyDTORequest p)
        {
            var response = await AddAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "Company");

            }
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> Update(CompanyDTORequest p)
        {
            var response = await UpdateAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "Company");

            }
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url+id);
            if (response)
            {
                return RedirectToAction("Index", "Company");

            }
            return RedirectToAction("Index", "Home");

        }

    }
}
