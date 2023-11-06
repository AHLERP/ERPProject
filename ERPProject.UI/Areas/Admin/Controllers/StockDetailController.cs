using ERPProject.Entity.DTO.StockDetailDTO;
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
            var val = await GetAllAsync<StockDetailDTOResponse>(url + "GetStockDetails");
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
        [HttpGet("/Admin/StokDetay")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<StockDetailDTOResponse>(url + "GetStockDetail/" + id);
            return View(val);
        }
        [HttpPost("/Admin/StokDetayEkle")]
        public async Task<IActionResult> Add(StockDetailDTORequest p)
        {
            var val = await AddAsync(p, url + "AddStockDetail");
            if (val)
            {
                return RedirectToAction("Index", "StockDetail");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/StokDetayGuncelle")]
        public async Task<IActionResult> Update(StockDetailDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateStockDetail");
            if (val)
            {
                return RedirectToAction("Index", "StockDetail");

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
