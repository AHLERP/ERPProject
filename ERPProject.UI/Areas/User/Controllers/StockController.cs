using ERPProject.Entity.DTO.StockDTO;
using Microsoft.AspNetCore.Mvc;

using ERPProject.Entity.DTO.StockDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class StockController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public StockController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Kullanici/Stoklar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<StockDTOResponse>(url + "GetStocks");
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            return View(val);
            return View(val);
        }
        [HttpGet("/Kullanici/Stok")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<StockDTOResponse>(url + "GetStock/" + id);
            return View(val);
        }
        [HttpPost("/Kullanici/StokEkle")]
        public async Task<IActionResult> Add(StockDTORequest p)
        {
            var val = await AddAsync(p, url + "AddStock");
            if (val)
            {
                return RedirectToAction("Index", "Stock");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Kullanici/StokGuncelle")]
        public async Task<IActionResult> Update(StockDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateStock");
            if (val)
            {
                return RedirectToAction("Index", "Stock");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Kullanici/StokSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url + "RemoveStock/" + id);
            if (val)
            {
                return RedirectToAction("Index", "Stock");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
