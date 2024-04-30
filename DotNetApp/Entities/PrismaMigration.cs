using System;
using System.Collections.Generic;

namespace DotNetApp.Entities;

public partial class PrismaMigration
{
    public string Id { get; set; }

    public string Checksum { get; set; }

    public DateTime? FinishedAt { get; set; }

    public string MigrationName { get; set; }

    public string Logs { get; set; }

    public DateTime? RolledBackAt { get; set; }

    public DateTime StartedAt { get; set; }

    public uint AppliedStepsCount { get; set; }
}
