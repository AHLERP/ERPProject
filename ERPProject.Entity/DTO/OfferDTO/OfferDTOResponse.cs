using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.OfferDTO
{
    public class OfferDTOResponse : OfferDTOBase
    {
        public string UserName { get; set; } = null!;
        public string RequestName { get; set; } = null!;
    }
}
