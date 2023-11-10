using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.ProductDTO
{
    public class ProductDTORequest:ProductDTOBase
    {
        public long? AddedUser { get; set; }

        public long? UpdatedUser { get; set; }
    }
}
