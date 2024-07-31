using System;
using System.Collections.Generic;

namespace TvDordrecht.Models;

public partial class TrainingSessionParticipant
{
    public int Id { get; set; }

    public int SessionId { get; set; }

    public int UserId { get; set; }

    public virtual TrainingSession Session { get; set; } = null!;

    public virtual AuthUser User { get; set; } = null!;
}
