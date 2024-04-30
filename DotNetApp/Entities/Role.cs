using System;
using System.Collections.Generic;

namespace DotNetApp.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
