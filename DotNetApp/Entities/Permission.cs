using System;
using System.Collections.Generic;

namespace DotNetApp.Entities;

public partial class Permission
{
    public int Id { get; set; }

    public string Module { get; set; }

    public string Action { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int? Order { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
