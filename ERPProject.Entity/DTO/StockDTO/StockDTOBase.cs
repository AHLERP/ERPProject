using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.StockDTO
{
    public class StockDTOBase
    {
        public long Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public short QuantityUnit { get; set; }

        public string? Description { get; set; }

        public int CompanyId { get; set; }
    }
}
