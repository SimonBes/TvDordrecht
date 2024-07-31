using System;
using System.Collections.Generic;

namespace TvDordrecht.Models;

public partial class AuthUser
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public DateTime? LastLogin { get; set; }

    public bool IsSuperuser { get; set; }

    public string Username { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsStaff { get; set; }

    public bool IsActive { get; set; }

    public DateTime DateJoined { get; set; }

    public virtual ICollection<AuthUserGroup> AuthUserGroups { get; set; } = new List<AuthUserGroup>();

    public virtual ICollection<AuthUserUserPermission> AuthUserUserPermissions { get; set; } = new List<AuthUserUserPermission>();

    public virtual ICollection<DjangoAdminLog> DjangoAdminLogs { get; set; } = new List<DjangoAdminLog>();

    public virtual ICollection<RaceDistance> RaceDistanceLastModifiedBies { get; set; } = new List<RaceDistance>();

    public virtual ICollection<RaceDistance> RaceDistanceOwners { get; set; } = new List<RaceDistance>();

    public virtual ICollection<RaceEvent> RaceEventLastModifiedBies { get; set; } = new List<RaceEvent>();

    public virtual ICollection<RaceEvent> RaceEventOwners { get; set; } = new List<RaceEvent>();

    public virtual ICollection<RaceResult> RaceResultLastModifiedBies { get; set; } = new List<RaceResult>();

    public virtual ICollection<RaceResult> RaceResultOwners { get; set; } = new List<RaceResult>();

    public virtual ICollection<RaceResult> RaceResultUsers { get; set; } = new List<RaceResult>();

    public virtual ICollection<SwimtestRecord> SwimtestRecords { get; set; } = new List<SwimtestRecord>();

    public virtual ICollection<TrainingSessionParticipant> TrainingSessionParticipants { get; set; } = new List<TrainingSessionParticipant>();

    public virtual ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();

    public virtual ICollection<WebappImage> WebappImageLastModifiedBies { get; set; } = new List<WebappImage>();

    public virtual ICollection<WebappImage> WebappImageOwners { get; set; } = new List<WebappImage>();

    public virtual ICollection<WebappMenu> WebappMenuLastModifiedBies { get; set; } = new List<WebappMenu>();

    public virtual ICollection<WebappMenu> WebappMenuOwners { get; set; } = new List<WebappMenu>();

    public virtual ICollection<WebappNews> WebappNewsLastModifiedBies { get; set; } = new List<WebappNews>();

    public virtual ICollection<WebappNews> WebappNewsOwners { get; set; } = new List<WebappNews>();

    public virtual ICollection<WebappPage> WebappPageLastModifiedBies { get; set; } = new List<WebappPage>();

    public virtual ICollection<WebappPage> WebappPageOwners { get; set; } = new List<WebappPage>();
}
