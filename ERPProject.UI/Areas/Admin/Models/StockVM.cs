using ERPProject.Entity.DTO.DepartmentDTO;
using ERPProject.Entity.DTO.RequestDTO;
using ERPProject.Entity.DTO.StockDetailDTO;
using ERPProject.Entity.DTO.StockDTO;
using ERPProject.Entity.DTO.UserDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.UI.Areas.Admin.Models
{
    public class StockVM
    {
        public virtual ICollection<StockDTOResponse> Stocks { get; set; } = new List<StockDTOResponse>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
    }
}
