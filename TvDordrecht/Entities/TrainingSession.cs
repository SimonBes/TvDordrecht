using System;
using System.Collections.Generic;

namespace TvDordrecht.Models;

public partial class TrainingSession
{
    public int Id { get; set; }

    public DateTime Created { get; set; }

    public DateTime Modified { get; set; }

    public DateTime Start { get; set; }

    public int DisciplineId { get; set; }

    public int? LocationId { get; set; }

    public int? TrainerId { get; set; }

    public string Message { get; set; } = null!;

    public bool Cancel { get; set; }

    public virtual TrainingDiscipline Discipline { get; set; } = null!;

    public virtual TrainingLocation? Location { get; set; }

    public virtual AuthUser? Trainer { get; set; }

    public virtual ICollection<TrainingSessionParticipant> TrainingSessionParticipants { get; set; } = new List<TrainingSessionParticipant>();
}
