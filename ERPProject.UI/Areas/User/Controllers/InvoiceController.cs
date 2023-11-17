using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.InvoiceDTO;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.DTO.ProductDTO;
using ERPProject.Entity.Poco;
using ERPProject.UI.Areas.User.Models;
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
        [HttpGet("/Kullanici/Faturalar")]
        public async Task<IActionResult> Index()
        {
            var val = await GetAllAsync<InvoiceDTOResponse>(url + "GetInvoices");
            var val2 = await GetAllAsync<ProductDTOResponse>(url + "GetProducts");
            var val3 = await GetAllAsync<OfferDTOResponse>(url + "GetOffers");
            var val4 = await GetAllAsync<CompanyDTOResponse>(url + "GetCompanies");
            if (val.StatusCode == 401)
            {
                return RedirectToAction("Unauthorized", "Home");
            }
            else if (val.StatusCode == 403)
            {
                return RedirectToAction("Forbidden", "Home");
            }
            InvoiceVM invoiceVM = new InvoiceVM()

            {
                Invoices = val.Data,
                Products = val2.Data,
                Offers = val3.Data,
                Companies = val4.Data,

            };
            return View(invoiceVM);
        }
        [HttpGet("/Kullanici/Fatura")]
        public async Task<IActionResult> Get(long id)
        {
            var val = await GetAsync<InvoiceDTOResponse>(url + "GetInvoice/" + id);
            return View(val);
        }
        [HttpPost("/Kullanici/FaturaEkle")]
        public async Task<IActionResult> Add(InvoiceDTORequest p)
        {
            var val = await AddAsync(p, url + "AddInvoice");
            if (val.Data != null)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Kullanici/FaturaGuncelle")]
        public async Task<IActionResult> Update(InvoiceDTORequest p)
        {
            var val = await UpdateAsync(p, url + "UpdateInvoice");
            if (val.Data != null)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost("/Kullanici/FaturaSil")]
        public async Task<IActionResult> Delete(long id)
        {
            var val = await DeleteAsync(url + "RemoveInvoice/" + id);
            if (val)
            {
                return RedirectToAction("Index", "Invoice");

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
