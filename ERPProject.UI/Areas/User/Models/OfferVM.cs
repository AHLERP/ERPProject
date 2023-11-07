using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.OfferDTO;

namespace ERPProject.UI.Areas.User.Models
{
    public class OfferVM
    {
        public virtual ICollection<CompanyDTOResponse> Companies { get; set; } = new List<CompanyDTOResponse>();
        public virtual ICollection<OfferDTOResponse> Offers { get; set; } = new List<OfferDTOResponse>();
        public virtual ICollection<RequestDTOResponse> Requests { get; set; } = new List<RequestDTOResponse>();

    }
}
