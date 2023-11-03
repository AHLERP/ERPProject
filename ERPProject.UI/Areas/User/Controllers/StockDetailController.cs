using ERPProject.Entity.DTO.StockDetailDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class StockDetailController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public StockDetailController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/User/Stokdetaylar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<StockDetailDTOResponse>(url + "GetStockDetails");
            return View(val);
        }
        [HttpGet("/User/StokDetay")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<StockDetailDTOResponse>(url + "GetStockDetail/" + id);
            return View(val);
        }
        [HttpPost("/User/StokDetayEkle")]
        public async Task<IActionResult> Add(StockDetailDTORequest p)
        {
            var response = await AddAsync(p, url + "AddStockDetail");
            if (response)
            {
                return RedirectToAction("Index", "StockDetail");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/StokDetayGuncelle")]
        public async Task<IActionResult> Update(StockDetailDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateStockDetail");
            if (response)
            {
                return RedirectToAction("Index", "StockDetail");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/StokDetaySil")]
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
