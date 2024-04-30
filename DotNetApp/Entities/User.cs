using System;
using System.Collections.Generic;

namespace DotNetApp.Entities;

public partial class User
{
    public string Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public string Avatar { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
