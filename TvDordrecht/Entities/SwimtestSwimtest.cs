using System;
using System.Collections.Generic;

namespace TvDordrecht.Models;

public partial class SwimtestSwimtest
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public virtual ICollection<SwimtestRecord> SwimtestRecords { get; set; } = new List<SwimtestRecord>();
}
