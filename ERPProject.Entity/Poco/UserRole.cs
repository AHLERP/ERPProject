using ERPProject.Core.Entity;
using ERPProject.Entity.Base;
using System;
using System.Collections.Generic;

namespace ERPProject.Entity.Poco;

public partial class UserRole:BaseEntity
{
    public long UserId { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;



    //baseden gelen fieldları gizleme
    private new long AddedUser { get; set; }
    private new DateTime AddedTime { get; set; }

    private new DateTime? UpdatedTime { get; set; }

    private new string AddedIPV4Address { get; set; }

    private new string? UpdatedIPV4Address { get; set; }


    private new long? UpdatedUser { get; set; }
    private new bool IsActive { get; set; }
}
