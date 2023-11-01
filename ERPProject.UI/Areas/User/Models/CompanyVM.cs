using ERPProject.Entity.DTO.CategoryDTO;
using ERPProject.Entity.DTO.CompanyDTO;

namespace ERPProject.UI.Areas.User.Models
{
    public class CompanyVM
    {
        public virtual ICollection<CompanyDTOResponse> Companies { get; set; } = new List<CompanyDTOResponse>();

    }
}
