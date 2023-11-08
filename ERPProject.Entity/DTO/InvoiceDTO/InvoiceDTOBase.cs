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

        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public short QuantityUnit { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string SupplierName { get; set; }
        public string SupAddress { get; set; }

        public long OfferId { get; set; }

        public int CompanyId { get; set; }

        public int ProductId { get; set; }
    }
}
