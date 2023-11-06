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
        public CompanyController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Admin/Sirketler")]
        public async Task<IActionResult> Index()
        {
            var company = await GetAllAsync<CompanyDTOResponse>(url + "GetCompanies");
            var department = await GetAllAsync<DepartmentDTOResponse>(url + "GetDepartments");
            if (company.StatusCode == 401 || department.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (company.StatusCode == 403 || department.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }


            CompanyVM companyVM = new CompanyVM()

            {
                Companies = company.Data,
                Departments = department.Data,
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
            var response = await UpdateAsync(p, url + "UpdateCompany");
            if (response)
            {
                return RedirectToAction("Sirketler", "Admin");

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
