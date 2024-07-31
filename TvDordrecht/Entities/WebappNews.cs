using System;
using System.Collections.Generic;

namespace TvDordrecht.Models;

public partial class WebappNews
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Text { get; set; } = null!;

    public int? ImageId { get; set; }

    public string Slug { get; set; } = null!;

    public bool Publish { get; set; }

    public DateTime? PubDate { get; set; }

    public int? OwnerId { get; set; }

    public int? LastModifiedById { get; set; }

    public DateTime? LastModified { get; set; }

    public string Keywords { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual WebappImage? Image { get; set; }

    public virtual AuthUser? LastModifiedBy { get; set; }

    public virtual AuthUser? Owner { get; set; }
}
