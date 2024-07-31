using System;
using System.Collections.Generic;

namespace TvDordrecht.Models;

public partial class RaceResult
{
    public int Id { get; set; }

    public TimeOnly? Time { get; set; }

    public string Remarks { get; set; } = null!;

    public int UserId { get; set; }

    public DateOnly Date { get; set; }

    public int DistanceId { get; set; }

    public int EventId { get; set; }

    public DateTime? LastModified { get; set; }

    public int? LastModifiedById { get; set; }

    public int? OwnerId { get; set; }

    public DateTime? PubDate { get; set; }

    public virtual RaceDistance Distance { get; set; } = null!;

    public virtual RaceEvent Event { get; set; } = null!;

    public virtual AuthUser? LastModifiedBy { get; set; }

    public virtual AuthUser? Owner { get; set; }

    public virtual AuthUser User { get; set; } = null!;
}
