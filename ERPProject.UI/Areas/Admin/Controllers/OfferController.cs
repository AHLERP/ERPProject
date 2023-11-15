using ERPProject.Entity.DTO.InvoiceDTO;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Remotion.Configuration.TypeDiscovery;
using System.Net.Http;
using System.Text;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfferController : BaseController
    {
        private readonly HttpClient _httpClient;
        private readonly string url = "https://localhost:7075/";
        public OfferController(HttpClient httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet("/Admin/Teklifler")]
        public async Task<IActionResult> Index()
        {
            var id = HttpContext.Session.GetString("User");
            var dep = HttpContext.Session.GetString("DepartmentName");
            var role = HttpContext.Session.GetString("Role");
            if (dep == "Satın Alma" || role == "Şirket Müdürü")
            {
                var val2 = await GetAllAsync<UserDTOResponse>(url + "GetUsers");
                var val3 = await GetAllAsync<RequestDTOResponse>(url + "RequestsByCompany/" + id);
                var val = await GetAllAsync<OfferDTOResponse>(url + "GetOffers");
                OfferVM offerVM = null;
                if (val == null)
                {
                    offerVM = new OfferVM()

                        {
                            Offers = null,
                            Users = val2.Data,
                            Requests = val3.Data,

                        };
                        return View(offerVM);
                    }

                    if (val.StatusCode == 401)
                    {
                        return RedirectToAction("Unauthorized", "Home");
                    }
                    else if (val.StatusCode == 403)
                    {
                        return RedirectToAction("Forbidden", "Home");
                    }
                    offerVM = new OfferVM()

                    {
                        Offers = val.Data,
                        Users = val2.Data,
                        Requests = val3.Data,

                };
                return View(offerVM);
            }
            else if (role == "Admin" || role == "Yönetim Kurulu Başkanı")
            {
                var val2 = await GetAllAsync<UserDTOResponse>(url + "GetUsers");
                var val3 = await GetAllAsync<RequestDTOResponse>(url + "Requests");
                var val = await GetAllAsync<OfferDTOResponse>(url + "GetOffers");
                OfferVM offerVM = null;
                if (val == null)
                {
                    offerVM = new OfferVM()

                    {
                        Offers = null,
                        Users = val2.Data,
                        Requests = val3.Data,

                    };
                    return View(offerVM);
                }

                if (val.StatusCode == 401)
                {
                    return RedirectToAction("Unauthorized", "Home");
                }
                else if (val.StatusCode == 403)
                {
                    return RedirectToAction("Forbidden", "Home");
                }
                offerVM = new OfferVM()

                {
                    Offers = val.Data,
                    Users = val2.Data,
                    Requests = val3.Data,

                };
                return View(offerVM);
            }

            return RedirectToAction("Index", "Home");

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
            p.AddedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            var val = await AddAsync(p, url + "AddOffer");
            if (val != null)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/TeklifGuncelle")]
        public async Task<IActionResult> Update(OfferDTORequest p)
        {
            p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
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
        [HttpPost("/Admin/TeklifTopluGuncelle")]
        public async Task<IActionResult> UpdateAll(OfferDTORequest p)
        {
            p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            var val = await UpdateAsync(p, url + "UpdateAllOffer");
            if (val)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
