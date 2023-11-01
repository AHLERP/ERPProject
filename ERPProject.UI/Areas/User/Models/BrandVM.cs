using ERPProject.Entity.DTO.BrandDTO;
using ERPProject.Entity.DTO.CompanyDTO;

namespace ERPProject.UI.Areas.User.Models
{
    public class BrandVM
    {
        public virtual ICollection<BrandDTOResponse> Companies { get; set; } = new List<BrandDTOResponse>();

    }
}
