using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public CompanyController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/Sirketler")]
        public async Task<IActionResult> Index()
        {
            var company = await GetAllAsync<CompanyDTOResponse>(url + "GetCompanies");
            var department = await GetAllAsync<DepartmentDTOResponse>(url + "GetDepartments");
            CompanyVM companyVM = new CompanyVM() 
            
            {
                Companies = company,
                Departments = department,
            };


                return View(companyVM);
        }
        [HttpGet("/Admin/Sirket")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<CompanyDTOResponse>(url + "GetCompany/" + id);
            return View(val);
        }
        [HttpPost("/Admin/SirketEkle")]
        public async Task<IActionResult> AddCompany(CompanyDTORequest p)
        {
            var response = await AddAsync(p, url + "AddCompany");
            if (response)
            {
                return RedirectToAction("Index", "Company");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/SirketGuncelle")]
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
        [HttpGet("/Admin/SirketSil/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveCompany/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Company");
            }
            return RedirectToAction("Index", "Home");

        }

    }
}
