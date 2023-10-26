using ERPProject.Entity.Base;
using System;
using System.Collections.Generic;

namespace ERPProject.Entity.Poco;

public partial class StockDetail : BaseEntity
{
    public long Id { get; set; }

    public long StockId { get; set; }

    public int Quantity { get; set; }

    public long RecieverId { get; set; }

    public long DelivererId { get; set; }

    public virtual User Deliverer { get; set; } = null!;

    public virtual User Reciever { get; set; } = null!;

    public virtual Stock Stock { get; set; } = null!;
}
