using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.UI.Areas.Admin.Models.User
{
    public class UserVM
    {
        public long Id { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int RolId { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<RequestDTOResponse> Request { get; set; } = new List<RequestDTOResponse>();
        public virtual ICollection<DepartmentDTOResponse> Department { get; set; } = new List<DepartmentDTOResponse>();
        public virtual ICollection<Role> Role { get; set; } = new List<Role>();//DTO Response ile değiştir

    }
}
