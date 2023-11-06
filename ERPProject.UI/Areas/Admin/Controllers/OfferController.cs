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
            var offer = await GetAllAsync<OfferDTOResponse>(url + "GetOffers");
            var company = await GetAllAsync<CompanyDTOResponse>(url + "GetCompanies");
            OfferVM offerVM = new OfferVM()

            {

                Offers = offer.Data,
                Companies = company.Data,

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
            var response = await AddAsync(p, url + "AddOffer");
            if (response)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/TeklifGuncelle")]
        public async Task<IActionResult> Update(OfferDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateOffer");
            if (response)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/TeklifSil")]
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
