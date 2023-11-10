using ERPProject.Entity.DTO.StockDetailDTO;
using ERPProject.Entity.DTO.StockDTO;
using ERPProject.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StockDetailController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public StockDetailController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Admin/StokDetaylar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<StockDetailDTOResponse>(url + "StockDetails");
            var val1 = await GetAllAsync<StockDTOResponse>(url + "Stocks");
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            StockDetailVM stockDetailVM = new StockDetailVM
            {
                StockDetails = val.Data,
                Stocks = val1.Data
            };
            return View(stockDetailVM);
        }
        [HttpGet("/Admin/StokDetay")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<StockDetailDTOResponse>(url + "StockDetail/" + id);
            return View(val);
        }
        [HttpPost("/Admin/StokDetayEkle")]
        public async Task<IActionResult> Add(StockDetailDTORequest p)
        {
            var val = await AddAsync(p, url + "AddStockDetail");
            if (val.Data != null)
            {
                return RedirectToAction("Index", "Stock");

            }
            TempData["stok"] = "Stok Yetersiz...";
            return RedirectToAction("Index", "Stock");

        }
        [HttpPost("/Admin/StokDetayGuncelle")]
        public async Task<IActionResult> Update(StockDetailDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateStockDetail");
            if (val)
            {
                return RedirectToAction("Index", "Stock");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/StokDetaySil")]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url + "RemoveStockDetail/" + id);
            if (val)
            {
                return RedirectToAction("Index", "StockDetail");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
