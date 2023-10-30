using ERPProject.Entity.DTO.RequestDetailDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RequestDetailController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public RequestDetailController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/TalepDetaylar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<RequestDetailDTOResponse>(url + "GetRequestDetails");
            return View(val);
        }
        [HttpGet("/Admin/TalepDetay")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<RequestDetailDTOResponse>(url + "GetRequestDetail/" + id);
            return View(val);
        }
        [HttpPost("/Admin/TalepDetayEkle")]
        public async Task<IActionResult> Add(RequestDetailDTORequest p)
        {
            var response = await AddAsync(p, url + "AddRequestDetail");
            if (response)
            {
                return RedirectToAction("Index", "RequestDetail");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/TalepDetayGuncelle")]
        public async Task<IActionResult> Update(RequestDetailDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateRequestDetail");
            if (response)
            {
                return RedirectToAction("Index", "RequestDetail");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/TalepDetaySil")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveRequestDetail/" + id);
            if (response)
            {
                return RedirectToAction("Index", "RequestDetail");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
