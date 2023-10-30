using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.ProductDTO
{
    public class ProductDTOResponse:ProductDTOBase
    {
        public string BrandName { get; set; }
        public string CategoryName { get; set; }

    }
}
