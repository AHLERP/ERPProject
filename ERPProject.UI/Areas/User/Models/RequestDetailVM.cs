using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.ProductDTO;
using ERPProject.Entity.DTO.RequestDetailDTO;
using ERPProject.Entity.DTO.RequestDTO;

namespace ERPProject.UI.Areas.User.Models
{
    public class RequestDetailVM
    {
        public virtual ICollection<RequestDetailDTOResponse> RequestDetails { get; set; } = new List<RequestDetailDTOResponse>();
        public virtual ICollection<ProductDTOResponse> Products { get; set; } = new List<ProductDTOResponse>();

        public virtual ICollection<RequestDTOResponse> Requests { get; set; } = new List<RequestDTOResponse>();

    }
}
