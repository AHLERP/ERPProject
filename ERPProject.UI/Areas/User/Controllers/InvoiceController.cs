using ERPProject.Entity.DTO.InvoiceDTO;
using Microsoft.AspNetCore.Mvc;

namespace ERPProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class InvoiceController : BaseController
    {
        private readonly string url = "https://localhost:7075/";
        public InvoiceController(HttpClient httpClient) : base(httpClient)
        {

        }
        [HttpGet("/User/Faturalar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<InvoiceDTOResponse>(url + "GetInvoices");
            return View(val);
        }
        [HttpGet("/User/Fatura")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<InvoiceDTOResponse>(url + "GetInvoice/" + id);
            return View(val);
        }
        [HttpPost("/User/FaturaEkle")]
        public async Task<IActionResult> Add(InvoiceDTORequest p)
        {
            var response = await AddAsync(p, url + "AddInvoice");
            if (response)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/FaturaGuncelle")]
        public async Task<IActionResult> Update(InvoiceDTORequest p)
        {
            var response = await UpdateAsync(p, url + "UpdateInvoice");
            if (response)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/User/FaturaSil")]
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
