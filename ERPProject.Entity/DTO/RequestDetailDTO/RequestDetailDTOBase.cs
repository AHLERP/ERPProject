using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.RequestDetailDTO
{
    public class RequestDetailDTOBase
    {
        public long Id { get; set; }

        public long RequestId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
