using ERPProject.Entity.DTO.BrandDTO;
using Microsoft.AspNetCore.Mvc;

using ERPProject.Entity.DTO.BrandDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class BrandController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public BrandController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/User/Markalar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<BrandDTOResponse>(url + "GetBrands");
            return View(val);
        }
        [HttpGet("/User/Marka")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<BrandDTOResponse>(url + "GetBrand/" + id);
            return View(val);
        }
        [HttpPost("/User/MarkaEkle")]
        public async Task<IActionResult> Add(BrandDTORequest p)
        {
            var response = await AddAsync(p, url + "AddBrand");
            if (response)
            {
                return RedirectToAction("Index", "Brand");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/MarkaGuncelle")]
        public async Task<IActionResult> Update(BrandDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateBrand");
            if (response)
            {
                return RedirectToAction("Index", "Brand");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/MarkaSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveBrand/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Brand");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
