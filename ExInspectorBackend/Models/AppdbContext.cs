using Microsoft.EntityFrameworkCore;

namespace ExInspectorBackend.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

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
        public DbSet<ScheduleGroups> ScheduleGroups => Set<ScheduleGroups>();
        public DbSet<Schedules> Schedules => Set<Schedules>();
        public DbSet<WorkOrders> WorkOrders => Set<WorkOrders>();

        /// <summary>
        /// Do any database initialization required.
        /// </summary>
        /// <returns>A task that completes when the database is initialized</returns>
        public async Task InitializeDatabaseAsync()
        {
            await this.Database.EnsureCreatedAsync().ConfigureAwait(false);
        }
    }
}
