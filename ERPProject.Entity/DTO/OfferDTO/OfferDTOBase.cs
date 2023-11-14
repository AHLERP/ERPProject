using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.OfferDTO
{
    public class OfferDTOBase
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public long UserId { get; set; }

        public string SupplierName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string PriceStatus { get; set; } = null!;

        public int Status { get; set; }
        public long? AddedUser { get; set; }

        public long? UpdatedUser { get; set; }
    }
}
