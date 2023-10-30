using ERPProject.Entity.DTO.RequestDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("Admin")]
    public class RequestController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public RequestController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/Talepler")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<RequestDTOResponse>(url + "GetCompanies");
            return View(val);
        }
        [HttpGet("/Admin/Talep")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<RequestDTOResponse>(url + "GetRequest/" + id);
            return View(val);
        }
        [HttpPost("/Admin/TalepEkle")]
        public async Task<IActionResult> AddRequest(RequestDTORequest p)
        {
            var response = await AddAsync(p, url + "AddRequest");
            if (response)
            {
                return RedirectToAction("Index", "Request");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/TalepGuncelle")]
        public async Task<IActionResult> Update(RequestDTORequest p)
        {
            p.Id = 1;
            var response = await UpdateAsync(p, url + "UpdateRequest");
            if (response)
            {
                return RedirectToAction("Index", "Request");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/TalepSil")]
        public async Task<IActionResult> Delete(long id)
        {
            id = 3;
            var response = await DeleteAsync(url + "RemoveRequest/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Request");

            }
            return RedirectToAction("Index", "Home");

        }

    }
}
