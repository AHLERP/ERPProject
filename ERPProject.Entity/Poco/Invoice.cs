using ERPProject.Entity.Base;
using System;
using System.Collections.Generic;

namespace ERPProject.Entity.Poco;

public partial class Invoice : BaseEntity
{
    public int Id { get; set; }

    public long OfferId { get; set; }

    public int CompanyId { get; set; }

    public int ProductId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Offer Offer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
