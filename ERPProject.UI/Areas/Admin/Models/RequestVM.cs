using ERPProject.Entity.DTO.InvoiceDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.DTO.UserDTO;

namespace ERPProject.UI.Areas.Admin.Models
{
    public class RequestVM
    {
        public virtual ICollection<RequestDTORequest> Requests { get; set; } = new List<RequestDTORequest>();
        public virtual ICollection<UserDTORequest> Users { get; set; } = new List<UserDTORequest>();
    }
}
