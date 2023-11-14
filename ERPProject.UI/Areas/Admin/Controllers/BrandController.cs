using ERPProject.Entity.DTO.BrandDTO;
using ERPProject.Entity.Poco;
using ERPProject.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public BrandController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Admin/Markalar")]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Department")=="Satın Alma"|| HttpContext.Session.GetString("Role")=="Admin") 
            {
                var val = await GetAllAsync<BrandDTOResponse>(url + "GetBrands");
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

           return RedirectToAction("Index", "UserHome");
        }
        [HttpGet("/Admin/Marka")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<BrandDTOResponse>(url + "GetBrand/" + id);
            
            return View(val);
        }
        [HttpPost("/Admin/MarkaEkle")]
        public async Task<IActionResult> Add(BrandDTORequest p)
        {
            p.AddedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            var val = await AddAsync(p, url + "AddBrand");
            if (val.Data != null)
            {
                return RedirectToAction("Index", "Brand");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/MarkaGuncelle")]
        public async Task<IActionResult> Update(BrandDTORequest p)
        {
            p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            var val = await UpdateAsync(p, url + "UpdateBrand");
            if (val)
            {
                return RedirectToAction("Index", "Brand");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet("/Admin/MarkaSil/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url + "RemoveBrand/" + id);
            if (val)
            {
                return RedirectToAction("Index", "Brand");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}