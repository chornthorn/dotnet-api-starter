using System;
using System.Collections.Generic;

namespace DotNetApp.Entities;

public partial class UserRole
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public int RoleId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Role Role { get; set; }

    public virtual User User { get; set; }
}
