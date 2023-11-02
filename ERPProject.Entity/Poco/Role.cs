using ERPProject.Entity.Base;
using System;
using System.Collections.Generic;

namespace ERPProject.Entity.Poco;

public partial class Role : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
