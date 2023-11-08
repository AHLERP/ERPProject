using ERPProject.Entity.Base;
using System;
using System.Collections.Generic;

namespace ERPProject.Entity.Poco;

public partial class Invoice : BaseEntity
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

    public virtual Company Company { get; set; } = null!;

    public virtual Offer Offer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
