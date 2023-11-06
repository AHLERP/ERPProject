using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.Poco;
using ERPProject.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public OfferController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/Admin/Teklifler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<OfferDTOResponse>(url + "GetOffers");
            var val2 = await GetAllAsync<CompanyDTOResponse>(url + "GetCompanies");
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            OfferVM offerVM = new OfferVM()

            {

                Offers = val.Data,
                Companies = val2.Data,

            };
            return View(offerVM);
        }
        [HttpGet("/Admin/Teklif")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<OfferDTOResponse>(url + "GetOffer/" + id);
            return View(val);
        }
        [HttpPost("/Admin/TeklifEkle")]
        public async Task<IActionResult> Add(OfferDTORequest p)
        {
            var val = await AddAsync(p, url + "AddOffer");
            if (val)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/TeklifGuncelle")]
        public async Task<IActionResult> Update(OfferDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateOffer");
            if (val)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/TeklifSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url + "RemoveOffer/" + id);
            if (val)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
