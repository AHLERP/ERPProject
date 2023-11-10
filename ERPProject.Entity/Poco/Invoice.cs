using ERPProject.Entity.Base;
using System;
using System.Collections.Generic;

namespace ERPProject.Entity.Poco;

public partial class Invoice : BaseEntity
{
    public DateTime InvoiceDate { get; set; }
    public int Id { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public short QuantityUnit { get; set; }
    public string SupplierName { get; set; }
    public string ProductName { get; set; }
    public string CompanyName { get; set; }
}

