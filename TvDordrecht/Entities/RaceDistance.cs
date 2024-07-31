using System;
using System.Collections.Generic;

namespace TvDordrecht.Models;

public partial class RaceDistance
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Order { get; set; } = null!;

    public DateTime? LastModified { get; set; }

    public int? LastModifiedById { get; set; }

    public int? OwnerId { get; set; }

    public DateTime? PubDate { get; set; }

    public virtual AuthUser? LastModifiedBy { get; set; }

    public virtual AuthUser? Owner { get; set; }

    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();
}
