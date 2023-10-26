using ERPProject.Entity.Base;
using System;
using System.Collections.Generic;

namespace ERPProject.Entity.Poco;

public partial class RequestDetail : BaseEntity
{
    public long Id { get; set; }

    public long RequestId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;
}
