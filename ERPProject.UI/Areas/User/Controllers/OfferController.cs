using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.InvoiceDTO;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.Poco;
using ERPProject.UI.Areas.User.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class OfferController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public OfferController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/User/Teklifler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<OfferDTOResponse>(url + "GetOffers");
            var val2 = await GetAllAsync<UserDTOResponse>(url + "GetUsers");
            var val3 = await GetAllAsync<RequestDTOResponse>(url + "Requests");
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
                Users = val2.Data,
                Requests = val3.Data,
            };
            return View(offerVM);
        }
        [HttpGet("/User/Teklif")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<OfferDTOResponse>(url + "GetOffer/" + id);
            return View(val);
        }
        [HttpPost("/User/TeklifEkle")]
        public async Task<IActionResult> Add(OfferDTORequest p)
        {
            var val = await AddAsync(p, url + "AddOffer");
            if (val)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/TeklifGuncelle")]
        public async Task<IActionResult> Update(OfferDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateOffer");
            if (val)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/TeklifSil")]
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
