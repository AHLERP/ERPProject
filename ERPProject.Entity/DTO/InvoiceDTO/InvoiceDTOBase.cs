using ERPProject.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity.DTO.InvoiceDTO
{
    public class InvoiceDTOBase
    {
        public DateTime InvoiceDate { get; set; }
        public long Id { get; set; }
        public decimal TotalPrice { get; set; }
        public string SupplierName { get; set; }
        public string CompanyName { get; set; }


    }
}
