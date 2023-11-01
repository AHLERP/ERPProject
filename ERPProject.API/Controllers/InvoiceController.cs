using AutoMapper;
using ERPProject.Business.Abstract;
using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.DTO.InvoiceDTO;
using ERPProject.Entity.Poco;
using ERPProject.Entity.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ERPProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoiceController(IMapper mapper, IInvoiceService invoiceService)
        {
            _mapper = mapper;
            _invoiceService = invoiceService;
        }

        [HttpPost("/AddInvoice")]
        public async Task<IActionResult> AddInvoice(InvoiceDTORequest invoiceDTORequest)
        {
            Invoice invoice = _mapper.Map<Invoice>(invoiceDTORequest);
            await _invoiceService.AddAsync(invoice);

            InvoiceDTOResponse invoiceDTOResponse = _mapper.Map<InvoiceDTOResponse>(invoice);

            Log.Information("Invoices => {@invoiceDTOResponse}", invoiceDTOResponse);

            return Ok(Sonuc<InvoiceDTOResponse>.SuccessWithData(invoiceDTOResponse));
        }
        [HttpDelete("/RemoveInvoice/{invoiceId}")]
        public async Task<IActionResult> RemoveInvoice(int invoiceId)
        {
            Invoice invoice = await _invoiceService.GetAsync(x => x.Id == invoiceId);
            if (invoice == null)
            {
                return NotFound(Sonuc<InvoiceDTOResponse>.SuccessNoDataFound());
            }

            await _invoiceService.RemoveAsync(invoice);

            Log.Information("Invoices => {@invoice}", invoice);

            return Ok(Sonuc<InvoiceDTOResponse>.SuccessWithoutData());
        }

        [HttpPost("/UpdateInvoice")]
        public async Task<IActionResult> UpdateInvoice(InvoiceDTORequest invoiceDTORequest)
        {
            Invoice invoice = await _invoiceService.GetAsync(x => x.Id == invoiceDTORequest.Id);
            if (invoice == null)
            {
                return NotFound(Sonuc<InvoiceDTOResponse>.SuccessNoDataFound());
            }
            invoice = _mapper.Map(invoiceDTORequest, invoice);
            await _invoiceService.UpdateAsync(invoice);

            InvoiceDTOResponse invoiceDTOResponse = _mapper.Map<InvoiceDTOResponse>(invoice);

            Log.Information("Invoices => {@invoiceDTOResponse}", invoiceDTOResponse);

            return Ok(Sonuc<InvoiceDTOResponse>.SuccessWithData(invoiceDTOResponse));
        }

        [HttpGet("/GetInvoice/{invoiceId}")]
        public async Task<IActionResult> GetInvoice(int invoiceId)
        {
            Invoice invoice = await _invoiceService.GetAsync(x => x.Id == invoiceId);
            if (invoice == null)
            {
                return NotFound(Sonuc<InvoiceDTOResponse>.SuccessNoDataFound());
            }

            InvoiceDTOResponse invoiceDTOResponse = _mapper.Map<InvoiceDTOResponse>(invoice);

            Log.Information("Invoices => {@invoiceDTOResponse}", invoiceDTOResponse);

            return Ok(Sonuc<InvoiceDTOResponse>.SuccessWithData(invoiceDTOResponse));
        }

        [HttpGet("/GetInvoices")]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _invoiceService.GetAllAsync(x => x.IsActive == true, "Category", "Brand");
            if (invoices == null)
            {
                return NotFound(Sonuc<InvoiceDTOResponse>.SuccessNoDataFound());
            }

            List<InvoiceDTOResponse> invoiceDTOResponseList = new();
            foreach (var invoice in invoices)
            {
                invoiceDTOResponseList.Add(_mapper.Map<InvoiceDTOResponse>(invoice));
            }

            Log.Information("Invoices => {@invoiceDTOResponse}", invoiceDTOResponseList);

            return Ok(Sonuc<List<InvoiceDTOResponse>>.SuccessWithData(invoiceDTOResponseList));
        }

        [HttpGet("/GetInvoicesByOffer/{offerId}")]
        public async Task<IActionResult> GetInvoicesByOffer(int offerId)
        {
            var invoices = await _invoiceService.GetAllAsync(x => x.IsActive == true && x.OfferId == offerId, "Offer", "Company","Product");
            if (invoices == null)
            {
                return NotFound(Sonuc<InvoiceDTOResponse>.SuccessNoDataFound());
            }

            List<InvoiceDTOResponse> invoiceDTOResponseList = new();
            foreach (var invoice in invoices)
            {
                invoiceDTOResponseList.Add(_mapper.Map<InvoiceDTOResponse>(invoice));
            }

            Log.Information("Invoices => {@invoiceDTOResponse}", invoiceDTOResponseList);

            return Ok(Sonuc<List<InvoiceDTOResponse>>.SuccessWithData(invoiceDTOResponseList));
        }
        [HttpGet("/GetInvoicesByCompany/{companyId}")]
        public async Task<IActionResult> GetInvoicesByCompany(int companyId)
        {
            var invoices = await _invoiceService.GetAllAsync(x => x.IsActive == true && x.CompanyId == companyId, "Offer", "Company", "Product");
            if (invoices == null)
            {
                return NotFound(Sonuc<InvoiceDTOResponse>.SuccessNoDataFound());
            }

            List<InvoiceDTOResponse> invoiceDTOResponseList = new();
            foreach (var invoice in invoices)
            {
                invoiceDTOResponseList.Add(_mapper.Map<InvoiceDTOResponse>(invoice));
            }

            Log.Information("Invoices => {@invoiceDTOResponse}", invoiceDTOResponseList);

            return Ok(Sonuc<List<InvoiceDTOResponse>>.SuccessWithData(invoiceDTOResponseList));
        }
        [HttpGet("/GetInvoicesByProduct/{productId}")]
        public async Task<IActionResult> GetInvoicesByProduct(int productId)
        {
            var invoices = await _invoiceService.GetAllAsync(x => x.IsActive == true && x.ProductId == productId, "Offer", "Company", "Product");
            if (invoices == null)
            {
                return NotFound(Sonuc<InvoiceDTOResponse>.SuccessNoDataFound());
            }

            List<InvoiceDTOResponse> invoiceDTOResponseList = new();
            foreach (var invoice in invoices)
            {
                invoiceDTOResponseList.Add(_mapper.Map<InvoiceDTOResponse>(invoice));
            }

            Log.Information("Invoices => {@invoiceDTOResponse}", invoiceDTOResponseList);

            return Ok(Sonuc<List<InvoiceDTOResponse>>.SuccessWithData(invoiceDTOResponseList));
        }
    }
}
