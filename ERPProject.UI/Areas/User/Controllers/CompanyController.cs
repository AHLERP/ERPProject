using ERPProject.Entity.DTO.CompanyDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class CompanyController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public CompanyController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/User/Sirketler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<CompanyDTOResponse>(url + "GetCompanies");
            return View(val);
        }
        [HttpGet("/User/Sirket")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<CompanyDTOResponse>(url + "GetCompany/" + id);
            return View(val);
        }
        [HttpPost("/User/SirketEkle")]
        public async Task<IActionResult> AddCompany(CompanyDTORequest p)
        {
            var response = await AddAsync(p, url + "AddCompany");
            if (response)
            {
                return RedirectToAction("Index", "Company");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/SirketGuncelle")]
        public async Task<IActionResult> Update(CompanyDTORequest p)
        {
            p.Id = 1;
            var response = await UpdateAsync(p, url + "UpdateCompany");
            if (response)
            {
                return RedirectToAction("Index", "Company");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/SirketSil")]
        public async Task<IActionResult> Delete(long id)
        {
            id = 3;
            var response = await DeleteAsync(url + "RemoveCompany/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Company");

            }
            return RedirectToAction("Index", "Home");

        }

    }
}
