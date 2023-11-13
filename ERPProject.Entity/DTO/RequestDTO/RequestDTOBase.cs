using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.RequestDTO
{
    public class RequestDTOBase
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long? AcceptedId { get; set; }
        
        public int ProductId { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Quantity { get; set; }
        
        public decimal QuantityUnit { get; set; }
        
        public int RequestStatus { get; set; }
    }
}
