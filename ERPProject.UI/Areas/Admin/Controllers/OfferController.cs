using ERPProject.Entity.DTO.OfferDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public OfferController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/Teklifler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<OfferDTOResponse>(url + "GetOffers");
            return View(val);
        }
        [HttpGet("/Admin/Sirket")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<OfferDTOResponse>(url + "GetOffer/" + id);
            return View(val);
        }
        [HttpPost("/Admin/SirketEkle")]
        public async Task<IActionResult> Add(OfferDTORequest p)
        {
            var response = await AddAsync(p, url + "AddOffer");
            if (response)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/SirketGuncelle")]
        public async Task<IActionResult> Update(OfferDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateOffer");
            if (response)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/SirketSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveOffer/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
