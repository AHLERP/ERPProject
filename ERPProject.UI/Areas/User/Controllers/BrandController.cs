using ERPProject.Entity.DTO.BrandDTO;
using ERPProject.Entity.Poco;
using ERPProject.UI.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class BrandController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public BrandController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Kullanici/Markalar")]
        public async Task<IActionResult> Index()
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
        [HttpGet("/Kullanici/Marka")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<BrandDTOResponse>(url + "GetBrand/" + id);
            
            return View(val);
        }
        [HttpPost("/Kullanici/MarkaEkle")]
        public async Task<IActionResult> Add(BrandDTORequest p)
        {
            var val = await AddAsync(p, url + "AddBrand");
            if (val.Data != null)
            {
                return RedirectToAction("Index", "Brand");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Kullanici/MarkaGuncelle")]
        public async Task<IActionResult> Update(BrandDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateBrand");
            if (val)
            {
                return RedirectToAction("Index", "Brand");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpGet("/Kullanici/MarkaSil/{id}")]
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