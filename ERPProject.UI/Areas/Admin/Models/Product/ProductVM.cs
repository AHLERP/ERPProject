using ERPProject.Entity.DTO.BrandDTO;
using ERPProject.Entity.DTO.CategoryDTO;
using ERPProject.Entity.DTO.ProductDTO;
using ERPProject.Entity.Poco;

namespace ERPProject.UI.Areas.Admin.Models.Product
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }


        public virtual ICollection<ProductDTOResponse> Products { get; set; } = new List<ProductDTOResponse>();
        public virtual ICollection<CategoryDTOResponse> Categories { get; set; } = new List<CategoryDTOResponse>();
        public virtual ICollection<BrandDTOResponse> Brands { get; set; } = new List<BrandDTOResponse>();

    }
}
