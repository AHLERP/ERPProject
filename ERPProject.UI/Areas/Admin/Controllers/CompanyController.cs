using DocumentFormat.OpenXml.Drawing.Charts;
using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.Poco;
using ERPProject.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Net;

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
            var val = await GetAllAsync<CompanyDTOResponse>(url + "GetCompanies");
            var val2 = await GetAllAsync<DepartmentDTOResponse>(url + "GetDepartments");
            var id = HttpContext.Session.GetString("User");
            var dep = HttpContext.Session.GetString("DepartmentName");
            if (dep == "Admin" || dep == "Yonetim")
            {
                val = await GetAllAsync<CompanyDTOResponse>(url + "GetCompanies");
                if (val == null)
                {
                    return RedirectToAction("Forbidden", "Home");
                }
            }
            else
            {
                val = await GetAllAsync<CompanyDTOResponse>(url + "GetCompaniesByUser/" + id);
                if (val == null)
                {
                    return RedirectToAction("Forbidden", "Home");
                }
            }
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
        [HttpGet("/Admin/Sirket")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<CompanyDTOResponse>(url + "GetCompany/" + id);
            var dep = HttpContext.Session.GetString("DepartmanName");
            if (dep == "Admin" || dep == "Yönetim")
            {
                val = await GetAsync<CompanyDTOResponse>(url + "GetCompany/" + id);
            }
            else
            {
                return RedirectToAction("Forbidden", "Home");
            }
            if (val == null)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            return View(val);
        }
        [HttpPost("/Admin/SirketEkle")]
        public async Task<IActionResult> AddCompany(CompanyDTORequest p)
        {
            p.AddedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            var val = await AddAsync(p, url + "AddCompany");
            if (val == null)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            if (val.Data != null)
            {
                return RedirectToAction("Index", "Company");

            }
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            return RedirectToAction("Index", "Company");

        }
        [HttpPost("/Admin/SirketGuncelle")]
        public async Task<IActionResult> Update(CompanyDTORequest p)
        {
            p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            var val = await UpdateAsync(p, url + "UpdateCompany");
            if (val == null)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            if (val.Data != null)
            {
                return RedirectToAction("Sirketler", "Admin");

            }
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            return RedirectToAction("Index", "Company");

        }
        [HttpGet("/Admin/SirketSil/{id}")]
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
