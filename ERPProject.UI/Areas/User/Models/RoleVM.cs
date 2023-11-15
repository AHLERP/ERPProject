using ERPProject.Entity.DTO.RoleDTO;

namespace ERPProject.UI.Areas.User.Models
{
    public class RoleVM
    {
        public virtual ICollection<RoleDTOResponse> Roles { get; set; } = new List<RoleDTOResponse>();

    }
}
