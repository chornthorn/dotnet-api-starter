using System;
using System.Collections.Generic;

namespace DotNetApp.Entities;

public partial class Simple
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
