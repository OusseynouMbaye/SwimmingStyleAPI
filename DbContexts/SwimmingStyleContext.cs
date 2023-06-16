using Microsoft.EntityFrameworkCore;
using SwimmingStyleAPI.Entitites;

namespace SwimmingStyleAPI.DbContexts
{
    public class SwimmingStyleContext : DbContext
    {
        // db set for entities
        public DbSet<SwimmingStyleEntities> SwimmingStyles { get; set; } = null!;
        public DbSet<StatsSwimmingstyleEntities> StatsSwimmingStyles { get; set; } = null!;

        public SwimmingStyleContext(DbContextOptions<SwimmingStyleContext> options) : base(options)
        {
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            *//*modelBuilder.Entity<SwimmingStyleEntities>()
                .HasMany(s => s.StatsOfSwimmingStyle)
                .WithOne(s => s.SwimmingStyleEntitie)
                .HasForeignKey(s => s.SwimmingStyleEntitiesId);*//*
            modelBuilder.UseSerialColumns();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Server=localhost,1433;Database=SwimmingStyleDb;User Id=sa;Password=yourStrong(!)Password;");
            optionsBuilder.UseSqlite("Data Source=SwimmingStyleDb.db");
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}
