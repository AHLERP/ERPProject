using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.StockDetailDTO
{
    public class StockDetailDTOResponse:StockDetailDTOBase
    {
        public string StockName { get; set; }
        public string ProductName { get; set; }
        public DateTime? AddedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }
    }
}
