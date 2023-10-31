using ERPProject.Entity.DTO.InvoiceDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InvoiceController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public InvoiceController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }
        [HttpGet("/Admin/Faturalar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<InvoiceDTOResponse>(url + "GetInvoices");
            return View(val);
        }
        [HttpGet("/Admin/Fatura")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<InvoiceDTOResponse>(url + "GetInvoice/" + id);
            return View(val);
        }
        [HttpPost("/Admin/FaturaEkle")]
        public async Task<IActionResult> Add(InvoiceDTORequest p)
        {
            var response = await AddAsync(p, url + "AddInvoice");
            if (response)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/FaturaGuncelle")]
        public async Task<IActionResult> Update(InvoiceDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateInvoice");
            if (response)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Admin/FaturaSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await DeleteAsync(url + "RemoveInvoice/" + id);
            if (response)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
