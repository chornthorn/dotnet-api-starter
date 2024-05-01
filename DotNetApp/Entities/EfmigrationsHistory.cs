using System;
using System.Collections.Generic;

namespace DotNetApp.Entities;

public partial class EfmigrationsHistory
{
    public string MigrationId { get; set; }

    public string ProductVersion { get; set; }
}
