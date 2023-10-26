using ERPProject.Entity.Base;
using System;
using System.Collections.Generic;

namespace ERPProject.Entity.Poco;

public partial class Request : BaseEntity
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public long? AcceptedId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<RequestDetail> RequestDetails { get; set; } = new List<RequestDetail>();

    public virtual User User { get; set; } = null!;
}
