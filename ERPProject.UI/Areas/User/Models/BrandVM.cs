using ERPProject.Entity.DTO.BrandDTO;
using ERPProject.Entity.DTO.CompanyDTO;

namespace ERPProject.UI.Areas.User.Models
{
    public class BrandVM
    {
        public virtual ICollection<BrandDTOResponse> Brands { get; set; } = new List<BrandDTOResponse>();

    }
}
