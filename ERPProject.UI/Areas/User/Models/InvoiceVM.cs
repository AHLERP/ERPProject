using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.InvoiceDTO;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.DTO.ProductDTO;

namespace ERPProject.UI.Areas.User.Models
{
    public class InvoiceVM
    {

        public virtual ICollection<InvoiceDTOResponse> Invoices { get; set; } = new List<InvoiceDTOResponse>();
        public virtual ICollection<ProductDTOResponse> Products { get; set; } = new List<ProductDTOResponse>();
        public virtual ICollection<OfferDTOResponse> Offers { get; set; } = new List<OfferDTOResponse>();
        public virtual ICollection<CompanyDTOResponse> Companies { get; set; } = new List<CompanyDTOResponse>();

    }
}
