using System;
using System.Collections.Generic;

namespace TvDordrecht.Models;

public partial class WebappImage
{
    public int Id { get; set; }

    public string Image { get; set; } = null!;

    public string Caption { get; set; } = null!;

    public int? Sortorder { get; set; }

    public int Height { get; set; }

    public int Width { get; set; }

    public string ImageEditing { get; set; } = null!;

    public DateTime? PubDate { get; set; }

    public int? OwnerId { get; set; }

    public int? LastModifiedById { get; set; }

    public DateTime? LastModified { get; set; }

    public virtual AuthUser? LastModifiedBy { get; set; }

    public virtual AuthUser? Owner { get; set; }

    public virtual ICollection<RaceEvent> RaceEvents { get; set; } = new List<RaceEvent>();

    public virtual ICollection<WebappMenu> WebappMenus { get; set; } = new List<WebappMenu>();

    public virtual ICollection<WebappNews> WebappNews { get; set; } = new List<WebappNews>();

    public virtual ICollection<WebappPage> WebappPages { get; set; } = new List<WebappPage>();
}
