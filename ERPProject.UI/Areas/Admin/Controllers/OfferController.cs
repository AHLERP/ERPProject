using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
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
            var val = await GetAllAsync<OfferDTOResponse>(url + "GetOffers");
            if (val == null)
                return RedirectToAction("Forbidden", "Home");
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            if (dep == "Satın Alma" || dep == "Yonetim" || dep == "Admin")
            {
                var val2 = await GetAllAsync<UserDTOResponse>(url + "GetUsers");
                var val4 = await GetAllAsync<OfferDTOResponse>(url + "GetOffersByRequest/" + id);
                if (dep == "Yonetim")
                {
                    var val3 = await GetAllAsync<RequestDTOResponse>(url + "RequestsByCompany/" + id);
                    OfferVM offerVM = new OfferVM()
                    {
                        Offers = val4.Data,
                        Users = val2.Data,
                        Requests = val3.Data,

                    };
                    return View(offerVM);
                }
                else if (dep == "Admin" || dep == "Satın Alma")
                {
                    var val3 = await GetAllAsync<RequestDTOResponse>(url + "Requests");
                    OfferVM offerVM = new OfferVM()
                    {
                        Offers = val4.Data,
                        Users = val2.Data,
                        Requests = val3.Data,

                    };
                    return View(offerVM);
                }
            }
            return RedirectToAction("Forbidden", "Home");

        }
        [HttpGet("/Admin/Teklif")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<OfferDTOResponse>(url + "GetOffer/" + id);
            if (val.Data != null)
            {
                return View(val);
            }
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            return RedirectToAction("Forbidden", "Home");
        }
        [HttpPost("/Admin/TeklifEkle")]
        public async Task<IActionResult> Add(OfferDTORequest p)
        {
            p.AddedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            var dep = HttpContext.Session.GetString("DepartmentName");
            var val = await AddAsync(p, url + "AddOffer");
            if (dep == "Satın Alma" || dep == "Yonetim" || dep == "Admin")
            {
                if (val == null)
                {
                    return RedirectToAction("Forbidden", "Home");
                }
                if (val.Data != null)
                {
                    return RedirectToAction("Index", "Offer");

                }
            }
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            return RedirectToAction("Forbidden", "Home");

        }
        [HttpPost("/Admin/TeklifGuncelle")]
        public async Task<IActionResult> Update(OfferDTORequest p)
        {
            p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            var val = await UpdateAsync(p, url + "UpdateOffer");
            var dep = HttpContext.Session.GetString("DepartmentName");
            if (dep == "Satın Alma" || dep == "Yonetim" || dep == "Admin")
            {
                if (val == null)
                {
                    return RedirectToAction("Forbidden", "Home");
                }
                if (val.Data != null)
                {
                    return RedirectToAction("Index", "Offer");

                }
            }
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            return RedirectToAction("Forbidden", "Home");

        }
        [HttpPost("/Admin/TeklifSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url + "RemoveOffer/" + id);
            if (val)
            {
                return RedirectToAction("Index", "Offer");

            }
            return RedirectToAction("Forbidden", "Home");

        }
        [HttpPost("/Admin/TeklifTopluGuncelle")]
        public async Task<IActionResult> UpdateAll(OfferDTORequest p)
        {
            p.UpdatedUser = Convert.ToInt64(HttpContext.Session.GetString("User"));
            var val = await UpdateAsync(p, url + "UpdateAllOffer");
            var dep = HttpContext.Session.GetString("DepartmentName");
            if (dep == "Satın Alma" || dep == "Yonetim" || dep == "Admin")
            {
                if (val == null)
                {
                    return RedirectToAction("Forbidden", "Home");
                }
                if (val.Data != null)
                {
                    return RedirectToAction("Index", "Offer");

                }
            }
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            return RedirectToAction("Forbidden", "Home");

        }
    }
}
