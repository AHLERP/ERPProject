using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.RequestDTO
{
    public class RequestDTOResponse:RequestDTOBase
    {
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public string AcceptedName { get; set; }
    }
}
