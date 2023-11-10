using ERPProject.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.InvoiceDetailDTO
{
    public class InvoiceDetailDTOBase
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public short QuantityUnit { get; set; }
        public string ProductName { get; set; }
        public long InvoiceId { get; set; }
    }
}
