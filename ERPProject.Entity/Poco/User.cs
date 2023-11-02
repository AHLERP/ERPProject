﻿using ERPProject.Entity.Base;
using System;
using System.Collections.Generic;

namespace ERPProject.Entity.Poco;

public partial class User : BaseEntity
{
    public long Id { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<StockDetail> StockDetailDeliverers { get; set; } = new List<StockDetail>();

    public virtual ICollection<StockDetail> StockDetailRecievers { get; set; } = new List<StockDetail>();
}
