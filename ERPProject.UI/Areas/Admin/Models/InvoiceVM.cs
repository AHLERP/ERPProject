﻿using ERPProject.Entity.DTO.CompanyDTO;
using ERPProject.Entity.DTO.InvoiceDTO;
using ERPProject.Entity.DTO.OfferDTO;
using ERPProject.Entity.DTO.ProductDTO;

namespace ERPProject.UI.Areas.Admin.Models
{
    public class InvoiceVM
    {

        public virtual ICollection<InvoiceDTOResponse> Invoices { get; set; } = new List<InvoiceDTOResponse>();

    }
}
