using ERPProject.Entity.DTO.StockDetailDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("Admin")]
    public class StockDetailController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public StockDetailController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/Stokdetayları")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<StockDetailDTOResponse>(url + "GetStockDetails");
            return View(val);
        }
        [HttpGet("/Admin/StokDetay")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<StockDetailDTOResponse>(url + "GetStockDetail/" + id);
            return View(val);
        }
        [HttpPost("/Admin/StokDetayEkle")]
        public async Task<IActionResult> Add(StockDetailDTORequest p)
        {
            var response = await AddAsync(p, url + "AddStockDetail");
            if (response)
            {
                return RedirectToAction("Index", "StockDetail");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/StokDetayGuncelle")]
        public async Task<IActionResult> Update(StockDetailDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateStockDetail");
            if (response)
            {
                return RedirectToAction("Index", "StockDetail");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/StokDetaySil")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveStockDetail/" + id);
            if (response)
            {
                return RedirectToAction("Index", "StockDetail");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
