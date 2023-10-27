using ERPProject.Entity.DTO.OfferDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    public class OfferController : BaseController
    {
        private readonly string url = "";
        public OfferController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<OfferDTOResponse>(url);
            return View(val);
        }
        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<OfferDTOResponse>(url + id);
            return View(val);
        }
        [HttpPost]
        public async Task<IActionResult> Add(OfferDTORequest p)
        {
            var response = await AddAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Update(OfferDTORequest p)
        {
            var response = await UpdateAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + id);
            if (response)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
