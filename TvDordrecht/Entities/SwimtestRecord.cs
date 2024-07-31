using System;
using System.Collections.Generic;

namespace TvDordrecht.Models;

public partial class SwimtestRecord
{
    public int Id { get; set; }

    public int SwimTestId { get; set; }

    public int UserId { get; set; }

    public TimeOnly Time100 { get; set; }

    public TimeOnly Time200 { get; set; }

    public TimeOnly Time300 { get; set; }

    public TimeOnly Time400 { get; set; }

    public TimeOnly Time500 { get; set; }

    public TimeOnly? Split100 { get; set; }

    public TimeOnly? Split200 { get; set; }

    public TimeOnly? Split300 { get; set; }

    public TimeOnly? Split400 { get; set; }

    public TimeOnly? Split500 { get; set; }

    public TimeOnly PaceTime { get; set; }

    public string Remarks { get; set; } = null!;

    public virtual SwimtestSwimtest SwimTest { get; set; } = null!;

    public virtual AuthUser User { get; set; } = null!;
}
