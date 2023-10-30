using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.InvoiceDTO;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.DTO.ProductDTO;

namespace ERPProject.UI.Areas.Admin.Models.Invoice
{
    public class InvoiceVM
    {
        public int Id { get; set; }
        public long OfferId { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public string SupplierName { get; set; }
        public string CompanyName { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<InvoiceDTOResponse> Invoices { get; set; } = new List<InvoiceDTOResponse>();
        public virtual ICollection<ProductDTOResponse> Products { get; set; } = new List<ProductDTOResponse>();
        public virtual ICollection<OfferDTOResponse> Offers { get; set; } = new List<OfferDTOResponse>();
        public virtual ICollection<CompanyDTOResponse> Companies { get; set; } = new List<CompanyDTOResponse>();

    }
}
