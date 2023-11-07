using ERPProject.Entity.DTO.CategoryDTO;
using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.DepartmentDTO;

namespace ERPProject.UI.Areas.User.Models
{
    public class CompanyVM
    {
        public virtual ICollection<CompanyDTOResponse> Companies { get; set; } = new List<CompanyDTOResponse>();
        public virtual ICollection<DepartmentDTOResponse> Departments { get; set; } = new List<DepartmentDTOResponse>();

    }
}
