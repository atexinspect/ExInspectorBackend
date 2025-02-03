using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;

namespace ExInspectorBackend.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Asset> Asset => Set<Asset>();
    public DbSet<AssetType> AssetType => Set<AssetType>();
    public DbSet<Location> Location => Set<Location>();
    public DbSet<LocationSystems> LocationSystems => Set<LocationSystems>();
    public DbSet<LotDetails> LotDetails => Set<LotDetails>();
    public DbSet<LotSchedules> LotSchedules => Set<LotSchedules>();
    public DbSet<Manufacturers> Manufacturers => Set<Manufacturers>();
    public DbSet<MembershipRoles> MembershipRoles => Set<MembershipRoles>();
    public DbSet<MembershipTasks> MembershipTasks => Set<MembershipTasks>();
    public DbSet<MembershipUsers> MembershipUsers => Set<MembershipUsers>();
    public DbSet<MembershipUsersInRoles> MembershipUsersInRoles => Set<MembershipUsersInRoles>();
    public DbSet<Schedules> Schedules => Set<Schedules>();
    public DbSet<WorkOrders> WorkOrders => Set<WorkOrders>();


    public async Task InitializeDatabaseAsync()
    {
        _ = await Database.EnsureCreatedAsync();

        const string datasyncTrigger = @"
            CREATE OR ALTER TRIGGER [dbo].[{0}_datasync] ON [dbo].[{0}] AFTER INSERT, UPDATE AS
            BEGIN
                SET NOCOUNT ON;
                UPDATE
                    [dbo].[{0}]
                SET
                    [UpdatedAt] = SYSUTCDATETIME()
                WHERE
                    [Id] IN (SELECT [Id] FROM INSERTED);
            END
        "
        ;

        // Install the above trigger to set the UpdatedAt field automatically on insert or update.
        foreach (IEntityType table in Model.GetEntityTypes())
        {
            string sql = string.Format(datasyncTrigger, table.GetTableName());
            _ = await Database.ExecuteSqlRawAsync(sql);
        }
    }

    [SuppressMessage("Style", "IDE0058:Expression value is never used", Justification = "Model builder ignores return value.")]
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Tells EF Core that the TodoItem entity has a trigger.
        modelBuilder.Entity<Asset>()
            .ToTable(tb => tb.HasTrigger("Asset_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<AssetType>()
            .ToTable(tb => tb.HasTrigger("AssetType_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<Location>()
            .ToTable(tb => tb.HasTrigger("Location_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<LocationSystems>()
            .ToTable(tb => tb.HasTrigger("LocationSystems_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<LotDetails>()
            .ToTable(tb => tb.HasTrigger("LotDetails_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<LotSchedules>()
            .ToTable(tb => tb.HasTrigger("LotSchedules_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<Manufacturers>()
            .ToTable(tb => tb.HasTrigger("Manufacturers_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<MembershipRoles>()
            .ToTable(tb => tb.HasTrigger("MembershipRoles_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<MembershipTasks>()
            .ToTable(tb => tb.HasTrigger("MembershipTasks_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<MembershipUsers>()
            .ToTable(tb => tb.HasTrigger("MembershipUsers_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<MembershipUsersInRoles>()
            .ToTable(tb => tb.HasTrigger("MembershipUsersInRoles_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<Schedules>()
            .ToTable(tb => tb.HasTrigger("Schedules_datasync"));

        // Tells EF Core that the TodoList entity has a trigger.
        modelBuilder.Entity<WorkOrders>()
            .ToTable(tb => tb.HasTrigger("WorkOrders_datasync"));

        base.OnModelCreating(modelBuilder);
    }
}