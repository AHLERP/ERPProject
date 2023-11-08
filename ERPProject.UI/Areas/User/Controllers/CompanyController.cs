using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.Poco;
using ERPProject.UI.Areas.User.Models;
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
        [HttpGet("/Kullanici/Sirketler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<CompanyDTOResponse>(url + "GetCompanies");
            var val2 = await GetAllAsync<DepartmentDTOResponse>(url + "GetDepartments");
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }


            CompanyVM companyVM = new CompanyVM()

            {
                Companies = val.Data,
                Departments = val2.Data,
            };

            return View(companyVM);
        }
        [HttpGet("/Kullanici/Sirket")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<CompanyDTOResponse>(url + "GetCompany/" + id);

            return View(val);
        }
        [HttpPost("/Kullanici/SirketEkle")]
        public async Task<IActionResult> AddCompany(CompanyDTORequest p)
        {
            var val = await AddAsync(p, url + "AddCompany");

            if (val)
            {
                return RedirectToAction("Index", "Company");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Kullanici/SirketGuncelle")]
        public async Task<IActionResult> Update(CompanyDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateCompany");
            if (val)
            {
                return RedirectToAction("Sirketler", "User");

            }

            return RedirectToAction("Index", "Home");

        }
        [HttpGet("/Kullanici/SirketSil/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url + "RemoveCompany/" + id);
            if (val)
            {
                return RedirectToAction("Index", "Company");
            }
            return RedirectToAction("Index", "Home");

        }

    }
}
