using Microsoft.EntityFrameworkCore;
using TvDordrecht.Models;

namespace TvDordrecht.Context;

public partial class TvdContext : DbContext
{
    public TvdContext()
    {
    }

    public TvdContext(DbContextOptions<TvdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthGroup> AuthGroups { get; set; }

    public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; }

    public virtual DbSet<AuthPermission> AuthPermissions { get; set; }

    public virtual DbSet<AuthUser> AuthUsers { get; set; }

    public virtual DbSet<AuthUserGroup> AuthUserGroups { get; set; }

    public virtual DbSet<AuthUserUserPermission> AuthUserUserPermissions { get; set; }

    public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; }

    public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; }

    public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; }

    public virtual DbSet<DjangoSession> DjangoSessions { get; set; }

    public virtual DbSet<DjangoSite> DjangoSites { get; set; }

    public virtual DbSet<RaceDistance> RaceDistances { get; set; }

    public virtual DbSet<RaceEvent> RaceEvents { get; set; }

    public virtual DbSet<RaceResult> RaceResults { get; set; }

    public virtual DbSet<SwimtestRecord> SwimtestRecords { get; set; }

    public virtual DbSet<SwimtestSwimtest> SwimtestSwimtests { get; set; }

    public virtual DbSet<TrainingDiscipline> TrainingDisciplines { get; set; }

    public virtual DbSet<TrainingLocation> TrainingLocations { get; set; }

    public virtual DbSet<TrainingSession> TrainingSessions { get; set; }

    public virtual DbSet<TrainingSessionParticipant> TrainingSessionParticipants { get; set; }

    public virtual DbSet<WebappImage> WebappImages { get; set; }

    public virtual DbSet<WebappMenu> WebappMenus { get; set; }

    public virtual DbSet<WebappNews> WebappNews { get; set; }

    public virtual DbSet<WebappPage> WebappPages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=;Port=;Database=;Username=;Password=");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_group_pkey");

            entity.ToTable("auth_group");

            entity.HasIndex(e => e.Name, "auth_group_name_253ae2a6331666e8_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Name, "auth_group_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AuthGroupPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_group_permissions_pkey");

            entity.ToTable("auth_group_permissions");

            entity.HasIndex(e => e.GroupId, "auth_group_permissions_0e939a4f");

            entity.HasIndex(e => e.PermissionId, "auth_group_permissions_8373b171");

            entity.HasIndex(e => new { e.GroupId, e.PermissionId }, "auth_group_permissions_group_id_permission_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permissio_group_id_689710a9a73b7457_fk_auth_group_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthGroupPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_group_permission_id_1f49ccbbdc69d2fc_fk_auth_permission_id");
        });

        modelBuilder.Entity<AuthPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_permission_pkey");

            entity.ToTable("auth_permission");

            entity.HasIndex(e => e.ContentTypeId, "auth_permission_417f1b1c");

            entity.HasIndex(e => new { e.ContentTypeId, e.Codename }, "auth_permission_content_type_id_codename_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Codename)
                .HasMaxLength(100)
                .HasColumnName("codename");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.ContentType).WithMany(p => p.AuthPermissions)
                .HasForeignKey(d => d.ContentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_content_type_id_508cf46651277a81_fk_django_content_type_id");
        });

        modelBuilder.Entity<AuthUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_user_pkey");

            entity.ToTable("auth_user");

            entity.HasIndex(e => e.Username, "auth_user_username_51b3b110094b8aae_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Username, "auth_user_username_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateJoined).HasColumnName("date_joined");
            entity.Property(e => e.Email)
                .HasMaxLength(254)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsStaff).HasColumnName("is_staff");
            entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");
            entity.Property(e => e.LastLogin).HasColumnName("last_login");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .HasColumnName("username");
        });

        modelBuilder.Entity<AuthUserGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_user_groups_pkey");

            entity.ToTable("auth_user_groups");

            entity.HasIndex(e => e.GroupId, "auth_user_groups_0e939a4f");

            entity.HasIndex(e => e.UserId, "auth_user_groups_e8701ad4");

            entity.HasIndex(e => new { e.UserId, e.GroupId }, "auth_user_groups_user_id_group_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany(p => p.AuthUserGroups)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_group_id_33ac548dcf5f8e37_fk_auth_group_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserGroups)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_groups_user_id_4b5ed4ffdb8fd9b0_fk_auth_user_id");
        });

        modelBuilder.Entity<AuthUserUserPermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("auth_user_user_permissions_pkey");

            entity.ToTable("auth_user_user_permissions");

            entity.HasIndex(e => e.PermissionId, "auth_user_user_permissions_8373b171");

            entity.HasIndex(e => e.UserId, "auth_user_user_permissions_e8701ad4");

            entity.HasIndex(e => new { e.UserId, e.PermissionId }, "auth_user_user_permissions_user_id_permission_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PermissionId).HasColumnName("permission_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.AuthUserUserPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user__permission_id_384b62483d7071f0_fk_auth_permission_id");

            entity.HasOne(d => d.User).WithMany(p => p.AuthUserUserPermissions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("auth_user_user_permiss_user_id_7f0938558328534a_fk_auth_user_id");
        });

        modelBuilder.Entity<DjangoAdminLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("django_admin_log_pkey");

            entity.ToTable("django_admin_log");

            entity.HasIndex(e => e.ContentTypeId, "django_admin_log_417f1b1c");

            entity.HasIndex(e => e.UserId, "django_admin_log_e8701ad4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionFlag).HasColumnName("action_flag");
            entity.Property(e => e.ActionTime).HasColumnName("action_time");
            entity.Property(e => e.ChangeMessage).HasColumnName("change_message");
            entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");
            entity.Property(e => e.ObjectId).HasColumnName("object_id");
            entity.Property(e => e.ObjectRepr)
                .HasMaxLength(200)
                .HasColumnName("object_repr");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ContentType).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.ContentTypeId)
                .HasConstraintName("djan_content_type_id_697914295151027a_fk_django_content_type_id");

            entity.HasOne(d => d.User).WithMany(p => p.DjangoAdminLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("django_admin_log_user_id_52fdd58701c5f563_fk_auth_user_id");
        });

        modelBuilder.Entity<DjangoContentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("django_content_type_pkey");

            entity.ToTable("django_content_type");

            entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_45f3b1d93ec8c61c_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AppLabel)
                .HasMaxLength(100)
                .HasColumnName("app_label");
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .HasColumnName("model");
        });

        modelBuilder.Entity<DjangoMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("django_migrations_pkey");

            entity.ToTable("django_migrations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.App)
                .HasMaxLength(255)
                .HasColumnName("app");
            entity.Property(e => e.Applied).HasColumnName("applied");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DjangoSession>(entity =>
        {
            entity.HasKey(e => e.SessionKey).HasName("django_session_pkey");

            entity.ToTable("django_session");

            entity.HasIndex(e => e.ExpireDate, "django_session_de54fa62");

            entity.HasIndex(e => e.SessionKey, "django_session_session_key_461cfeaa630ca218_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.Property(e => e.SessionKey)
                .HasMaxLength(40)
                .HasColumnName("session_key");
            entity.Property(e => e.ExpireDate).HasColumnName("expire_date");
            entity.Property(e => e.SessionData).HasColumnName("session_data");
        });

        modelBuilder.Entity<DjangoSite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("django_site_pkey");

            entity.ToTable("django_site");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Domain)
                .HasMaxLength(100)
                .HasColumnName("domain");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RaceDistance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("race_distance_pkey");

            entity.ToTable("race_distance");

            entity.HasIndex(e => e.OwnerId, "race_distance_5e7b1936");

            entity.HasIndex(e => e.LastModifiedById, "race_distance_7fa85557");

            entity.HasIndex(e => e.Name, "race_distance_name_5fb66812e552159e_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Name, "race_distance_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LastModified).HasColumnName("last_modified");
            entity.Property(e => e.LastModifiedById).HasColumnName("last_modified_by_id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Order)
                .HasMaxLength(200)
                .HasColumnName("order");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PubDate).HasColumnName("pub_date");

            entity.HasOne(d => d.LastModifiedBy).WithMany(p => p.RaceDistanceLastModifiedBies)
                .HasForeignKey(d => d.LastModifiedById)
                .HasConstraintName("race_dista_last_modified_by_id_74371722d859f55e_fk_auth_user_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.RaceDistanceOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("race_distance_owner_id_3bf3b2e8ef76e480_fk_auth_user_id");
        });

        modelBuilder.Entity<RaceEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("race_event_pkey");

            entity.ToTable("race_event");

            entity.HasIndex(e => e.OwnerId, "race_event_5e7b1936");

            entity.HasIndex(e => e.LastModifiedById, "race_event_7fa85557");

            entity.HasIndex(e => e.ImageId, "race_event_f33175e6");

            entity.HasIndex(e => e.Name, "race_event_name_3df55be8c13479c8_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Name, "race_event_name_key").IsUnique();

            entity.HasIndex(e => e.Slug, "race_event_slug_23bb4cfad9878bd0_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Slug, "race_event_slug_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(200)
                .HasColumnName("city");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.LastModified).HasColumnName("last_modified");
            entity.Property(e => e.LastModifiedById).HasColumnName("last_modified_by_id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PubDate).HasColumnName("pub_date");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .HasColumnName("slug");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.Website)
                .HasMaxLength(200)
                .HasColumnName("website");

            entity.HasOne(d => d.Image).WithMany(p => p.RaceEvents)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("race_event_image_id_39c66c5b30f91b5c_fk_webapp_image_id");

            entity.HasOne(d => d.LastModifiedBy).WithMany(p => p.RaceEventLastModifiedBies)
                .HasForeignKey(d => d.LastModifiedById)
                .HasConstraintName("race_event_last_modified_by_id_7ead52594bfa5608_fk_auth_user_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.RaceEventOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("race_event_owner_id_79440a72cb885616_fk_auth_user_id");
        });

        modelBuilder.Entity<RaceResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("race_result_pkey");

            entity.ToTable("race_result");

            entity.HasIndex(e => e.EventId, "race_result_4437cfac");

            entity.HasIndex(e => e.OwnerId, "race_result_5e7b1936");

            entity.HasIndex(e => e.LastModifiedById, "race_result_7fa85557");

            entity.HasIndex(e => e.DistanceId, "race_result_a5eacca9");

            entity.HasIndex(e => e.UserId, "race_result_e8701ad4");

            entity.HasIndex(e => new { e.UserId, e.EventId, e.Date, e.DistanceId }, "race_result_user_id_5b1250046762f1a_uniq").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DistanceId).HasColumnName("distance_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.LastModified).HasColumnName("last_modified");
            entity.Property(e => e.LastModifiedById).HasColumnName("last_modified_by_id");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PubDate).HasColumnName("pub_date");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .HasColumnName("remarks");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Distance).WithMany(p => p.RaceResults)
                .HasForeignKey(d => d.DistanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("race_result_distance_id_38146a2931e2232d_fk_race_distance_id");

            entity.HasOne(d => d.Event).WithMany(p => p.RaceResults)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("race_result_event_id_4f74cd5968dd8bc5_fk_race_event_id");

            entity.HasOne(d => d.LastModifiedBy).WithMany(p => p.RaceResultLastModifiedBies)
                .HasForeignKey(d => d.LastModifiedById)
                .HasConstraintName("race_resul_last_modified_by_id_1b8f7c26817c7742_fk_auth_user_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.RaceResultOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("race_result_owner_id_540017c2bd973734_fk_auth_user_id");

            entity.HasOne(d => d.User).WithMany(p => p.RaceResultUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("race_result_user_id_d8476dc9e32c8a1_fk_auth_user_id");
        });

        modelBuilder.Entity<SwimtestRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("swimtest_record_pkey");

            entity.ToTable("swimtest_record");

            entity.HasIndex(e => e.SwimTestId, "swimtest_record_0554b69c");

            entity.HasIndex(e => e.UserId, "swimtest_record_e8701ad4");

            entity.HasIndex(e => new { e.SwimTestId, e.UserId }, "swimtest_record_swim_test_id_user_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PaceTime).HasColumnName("pace_time");
            entity.Property(e => e.Remarks)
                .HasMaxLength(200)
                .HasColumnName("remarks");
            entity.Property(e => e.Split100).HasColumnName("split_100");
            entity.Property(e => e.Split200).HasColumnName("split_200");
            entity.Property(e => e.Split300).HasColumnName("split_300");
            entity.Property(e => e.Split400).HasColumnName("split_400");
            entity.Property(e => e.Split500).HasColumnName("split_500");
            entity.Property(e => e.SwimTestId).HasColumnName("swim_test_id");
            entity.Property(e => e.Time100).HasColumnName("time_100");
            entity.Property(e => e.Time200).HasColumnName("time_200");
            entity.Property(e => e.Time300).HasColumnName("time_300");
            entity.Property(e => e.Time400).HasColumnName("time_400");
            entity.Property(e => e.Time500).HasColumnName("time_500");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.SwimTest).WithMany(p => p.SwimtestRecords)
                .HasForeignKey(d => d.SwimTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("swimtest__swim_test_id_3ae179ce61af0fed_fk_swimtest_swimtest_id");

            entity.HasOne(d => d.User).WithMany(p => p.SwimtestRecords)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("swimtest_record_user_id_1acd2dc8639f46c_fk_auth_user_id");
        });

        modelBuilder.Entity<SwimtestSwimtest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("swimtest_swimtest_pkey");

            entity.ToTable("swimtest_swimtest");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
        });

        modelBuilder.Entity<TrainingDiscipline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("training_discipline_pkey");

            entity.ToTable("training_discipline");

            entity.HasIndex(e => e.Slug, "training_discipline_slug_2c9c1172fac4c024_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Slug, "training_discipline_slug_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.Modified).HasColumnName("modified");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .HasColumnName("slug");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TrainingLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("training_location_pkey");

            entity.ToTable("training_location");

            entity.HasIndex(e => e.Slug, "training_location_slug_5ccd5f470c83bf5b_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Slug, "training_location_slug_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(200)
                .HasColumnName("city");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.Modified).HasColumnName("modified");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .HasColumnName("slug");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });

        modelBuilder.Entity<TrainingSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("training_session_pkey");

            entity.ToTable("training_session");

            entity.HasIndex(e => e.DisciplineId, "training_session_2a73e9e7");

            entity.HasIndex(e => e.TrainerId, "training_session_68153311");

            entity.HasIndex(e => e.LocationId, "training_session_e274a5da");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cancel).HasColumnName("cancel");
            entity.Property(e => e.Created).HasColumnName("created");
            entity.Property(e => e.DisciplineId).HasColumnName("discipline_id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.Message)
                .HasMaxLength(400)
                .HasColumnName("message");
            entity.Property(e => e.Modified).HasColumnName("modified");
            entity.Property(e => e.Start).HasColumnName("start");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");

            entity.HasOne(d => d.Discipline).WithMany(p => p.TrainingSessions)
                .HasForeignKey(d => d.DisciplineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("traini_discipline_id_1e5826cd4e530c2b_fk_training_discipline_id");

            entity.HasOne(d => d.Location).WithMany(p => p.TrainingSessions)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("training_s_location_id_62820d12fa5ce100_fk_training_location_id");

            entity.HasOne(d => d.Trainer).WithMany(p => p.TrainingSessions)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("training_session_trainer_id_4b56d873918e44a1_fk_auth_user_id");
        });

        modelBuilder.Entity<TrainingSessionParticipant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("training_session_participants_pkey");

            entity.ToTable("training_session_participants");

            entity.HasIndex(e => e.SessionId, "training_session_participants_7fc8ef54");

            entity.HasIndex(e => e.UserId, "training_session_participants_e8701ad4");

            entity.HasIndex(e => new { e.SessionId, e.UserId }, "training_session_participants_session_id_user_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Session).WithMany(p => p.TrainingSessionParticipants)
                .HasForeignKey(d => d.SessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("training_ses_session_id_727602c8640493b0_fk_training_session_id");

            entity.HasOne(d => d.User).WithMany(p => p.TrainingSessionParticipants)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("training_session_parti_user_id_28b57656863effbe_fk_auth_user_id");
        });

        modelBuilder.Entity<WebappImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("webapp_image_pkey");

            entity.ToTable("webapp_image");

            entity.HasIndex(e => e.OwnerId, "webapp_image_5e7b1936");

            entity.HasIndex(e => e.LastModifiedById, "webapp_image_7fa85557");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Caption)
                .HasMaxLength(600)
                .HasColumnName("caption");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .HasColumnName("image");
            entity.Property(e => e.ImageEditing)
                .HasMaxLength(100)
                .HasColumnName("image_editing");
            entity.Property(e => e.LastModified).HasColumnName("last_modified");
            entity.Property(e => e.LastModifiedById).HasColumnName("last_modified_by_id");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PubDate).HasColumnName("pub_date");
            entity.Property(e => e.Sortorder).HasColumnName("sortorder");
            entity.Property(e => e.Width).HasColumnName("width");

            entity.HasOne(d => d.LastModifiedBy).WithMany(p => p.WebappImageLastModifiedBies)
                .HasForeignKey(d => d.LastModifiedById)
                .HasConstraintName("webapp_ima_last_modified_by_id_2f5cb062e41ce5c5_fk_auth_user_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.WebappImageOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("webapp_image_owner_id_12fbfe9234bc8fa3_fk_auth_user_id");
        });

        modelBuilder.Entity<WebappMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("webapp_menu_pkey");

            entity.ToTable("webapp_menu");

            entity.HasIndex(e => e.OwnerId, "webapp_menu_5e7b1936");

            entity.HasIndex(e => e.LastModifiedById, "webapp_menu_7fa85557");

            entity.HasIndex(e => e.ImageId, "webapp_menu_f33175e6");

            entity.HasIndex(e => e.Slug, "webapp_menu_slug_35c2e67641732144_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Slug, "webapp_menu_slug_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Html).HasColumnName("html");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.Keywords).HasColumnName("keywords");
            entity.Property(e => e.LastModified).HasColumnName("last_modified");
            entity.Property(e => e.LastModifiedById).HasColumnName("last_modified_by_id");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PubDate).HasColumnName("pub_date");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .HasColumnName("slug");
            entity.Property(e => e.Sortorder).HasColumnName("sortorder");
            entity.Property(e => e.TableOfContents).HasColumnName("table_of_contents");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");

            entity.HasOne(d => d.Image).WithMany(p => p.WebappMenus)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("webapp_menu_image_id_1dbb52c986e08be8_fk_webapp_image_id");

            entity.HasOne(d => d.LastModifiedBy).WithMany(p => p.WebappMenuLastModifiedBies)
                .HasForeignKey(d => d.LastModifiedById)
                .HasConstraintName("webapp_men_last_modified_by_id_3ed4a7b38a54c094_fk_auth_user_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.WebappMenuOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("webapp_menu_owner_id_41bd0b513792ff5e_fk_auth_user_id");
        });

        modelBuilder.Entity<WebappNews>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("webapp_news_pkey");

            entity.ToTable("webapp_news");

            entity.HasIndex(e => e.OwnerId, "webapp_news_5e7b1936");

            entity.HasIndex(e => e.LastModifiedById, "webapp_news_7fa85557");

            entity.HasIndex(e => e.ImageId, "webapp_news_f33175e6");

            entity.HasIndex(e => e.Slug, "webapp_news_slug_7b6cec5edf447e5c_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Slug, "webapp_news_slug_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.Keywords).HasColumnName("keywords");
            entity.Property(e => e.LastModified).HasColumnName("last_modified");
            entity.Property(e => e.LastModifiedById).HasColumnName("last_modified_by_id");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PubDate).HasColumnName("pub_date");
            entity.Property(e => e.Publish).HasColumnName("publish");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .HasColumnName("slug");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");

            entity.HasOne(d => d.Image).WithMany(p => p.WebappNews)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("webapp_news_image_id_4529fd0576fa13b8_fk_webapp_image_id");

            entity.HasOne(d => d.LastModifiedBy).WithMany(p => p.WebappNewsLastModifiedBies)
                .HasForeignKey(d => d.LastModifiedById)
                .HasConstraintName("webapp_new_last_modified_by_id_34a68d66c0332a0c_fk_auth_user_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.WebappNewsOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("webapp_news_owner_id_750322d10ab21602_fk_auth_user_id");
        });

        modelBuilder.Entity<WebappPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("webapp_page_pkey");

            entity.ToTable("webapp_page");

            entity.HasIndex(e => e.OwnerId, "webapp_page_5e7b1936");

            entity.HasIndex(e => e.LastModifiedById, "webapp_page_7fa85557");

            entity.HasIndex(e => e.MenuId, "webapp_page_93e25458");

            entity.HasIndex(e => e.ImageId, "webapp_page_f33175e6");

            entity.HasIndex(e => new { e.MenuId, e.Slug }, "webapp_page_menu_id_slug_key").IsUnique();

            entity.HasIndex(e => e.Slug, "webapp_page_slug_541f84f0f3f9a880_like").HasOperators(new[] { "varchar_pattern_ops" });

            entity.HasIndex(e => e.Slug, "webapp_page_slug_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Html).HasColumnName("html");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.Keywords).HasColumnName("keywords");
            entity.Property(e => e.LastModified).HasColumnName("last_modified");
            entity.Property(e => e.LastModifiedById).HasColumnName("last_modified_by_id");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PubDate).HasColumnName("pub_date");
            entity.Property(e => e.Publish).HasColumnName("publish");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .HasColumnName("slug");
            entity.Property(e => e.Sortorder).HasColumnName("sortorder");
            entity.Property(e => e.TableOfContents).HasColumnName("table_of_contents");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");

            entity.HasOne(d => d.Image).WithMany(p => p.WebappPages)
                .HasForeignKey(d => d.ImageId)
                .HasConstraintName("webapp_page_image_id_6a260d608ab7e70c_fk_webapp_image_id");

            entity.HasOne(d => d.LastModifiedBy).WithMany(p => p.WebappPageLastModifiedBies)
                .HasForeignKey(d => d.LastModifiedById)
                .HasConstraintName("webapp_page_last_modified_by_id_ac2a755d568a948_fk_auth_user_id");

            entity.HasOne(d => d.Menu).WithMany(p => p.WebappPages)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("webapp_page_menu_id_2d475e54f681f4bf_fk_webapp_menu_id");

            entity.HasOne(d => d.Owner).WithMany(p => p.WebappPageOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("webapp_page_owner_id_789cd24e5ab0a66_fk_auth_user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
