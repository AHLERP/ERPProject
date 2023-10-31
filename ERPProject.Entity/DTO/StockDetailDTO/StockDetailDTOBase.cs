using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.StockDetailDTO
{
    public class StockDetailDTOBase
    {
        public long Id { get; set; }
        public int Quantity { get; set; }

        public long StockId { get; set; }

        public long RecieverId { get; set; }

        public long DelivererId { get; set; }
    }
}
