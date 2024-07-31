using System;
using System.Collections.Generic;

namespace TvDordrecht.Models;

public partial class TrainingLocation
{
    public int Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public string Title { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string Text { get; set; } = null!;

    public virtual ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();
}
