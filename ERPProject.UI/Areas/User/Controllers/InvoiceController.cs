using ERPProject.Entity.DTO.InvoiceDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    public class InvoiceController : BaseController
    {
        private readonly string url = "";
        public InvoiceController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<InvoiceDTOResponse>(url);
            return View(val);
        }
        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<InvoiceDTOResponse>(url + id);
            return View(val);
        }
        [HttpPost]
        public async Task<IActionResult> Add(InvoiceDTORequest p)
        {
            var response = await AddAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Update(InvoiceDTORequest p)
        {
            var response = await UpdateAsync(p, url);
            if (response)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + id);
            if (response)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
