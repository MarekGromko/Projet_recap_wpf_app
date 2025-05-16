using IdeaManager.Core.Entities;
using IdeaManager.Data.Configurations;
using IdeaManager.Data.DB;
using Microsoft.EntityFrameworkCore;

namespace IdeaManager.Data.Db
{
    public class IdeaDbContext : DbContext
    {
        public IdeaDbContext(DbContextOptions<IdeaDbContext> options) : base(options) { }
        public IdeaDbContext() : base()
        {
            // This constructor is used for migrations
        }

        public DbSet<Idea> Ideas => Set<Idea>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Vote> Votes => Set<Vote>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbFilePath = DBHelper.GetDatabasePath();
            optionsBuilder.UseSqlite($"Data Source={dbFilePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IdeaConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VoteConfiguration());
        }
    }
}

