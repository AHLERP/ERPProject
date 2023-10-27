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

        public string RecieverName { get; set; }

        public string DelivererName { get; set; }
    }
}
