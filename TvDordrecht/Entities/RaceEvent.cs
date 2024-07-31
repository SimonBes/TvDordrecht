using System;
using System.Collections.Generic;

namespace TvDordrecht.Models;

public partial class RaceEvent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string Website { get; set; } = null!;

    public DateTime? PubDate { get; set; }

    public DateTime? LastModified { get; set; }

    public int? ImageId { get; set; }

    public int? LastModifiedById { get; set; }

    public int? OwnerId { get; set; }

    public virtual WebappImage? Image { get; set; }

    public virtual AuthUser? LastModifiedBy { get; set; }

    public virtual AuthUser? Owner { get; set; }

    public virtual ICollection<RaceResult> RaceResults { get; set; } = new List<RaceResult>();
}
