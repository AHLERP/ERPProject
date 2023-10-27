using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.InvoiceDTO
{
    public class InvoiceDTOBase
    {
        public int Id { get; set; }

        public long OfferId { get; set; }

        public int CompanyId { get; set; }

        public int ProductId { get; set; }
    }
}
