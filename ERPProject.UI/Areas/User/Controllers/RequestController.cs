using ERPProject.Entity.DTO.RequestDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class RequestController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public RequestController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/User/Talepler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<RequestDTOResponse>(url + "GetCompanies");
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
        [HttpGet("/User/Talep")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<RequestDTOResponse>(url + "GetRequest/" + id);
            return View(val);
        }
        [HttpPost("/User/TalepEkle")]
        public async Task<IActionResult> AddRequest(RequestDTORequest p)
        {
            var val = await AddAsync(p, url + "AddRequest");
            if (val)
            {
                return RedirectToAction("Index", "Request");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/TalepGuncelle")]
        public async Task<IActionResult> Update(RequestDTORequest p)
        {
            p.Id = 1;
            var val = await UpdateAsync(p, url + "UpdateRequest");
            if (val)
            {
                return RedirectToAction("Index", "Request");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/TalepSil")]
        public async Task<IActionResult> Delete(long id)
        {
            id = 3;
            var val = await DeleteAsync(url + "RemoveRequest/" + id);
            if (val)
            {
                return RedirectToAction("Index", "Request");

            }
            return RedirectToAction("Index", "Home");

        }

    }
}
