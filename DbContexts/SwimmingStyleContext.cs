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

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<SwimmingStyleEntities>()
                 .HasMany(s => s.StatsOfSwimmingStyle)
                 .WithOne(s => s.SwimmingStyleEntitie)
                 .HasForeignKey(s => s.SwimmingStyleEntitiesId);
             modelBuilder.UseSerialColumns();
         }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SwimmingStyleEntities>().HasData(

                new SwimmingStyleEntities("Crawl")
                {
                    Id = 1,
                    Image = "freeStyle",
                    //Tags = tagsFree,
                    Description = "The front crawl or forward crawl, also known as the Australi",
                },
                new SwimmingStyleEntities("Butterfly")
                {
                    Id = 2,
                    Image = "Butterfly"
                });

            modelBuilder.Entity<StatsSwimmingstyleEntities>().HasData(
                new StatsSwimmingstyleEntities(2)
                {
                    Id = 1,
                    Endurance = 2,
                    Technique = 2,
                    Difficulty = 2,
                    SwimmingStyleEntitiesId = 1,
                },
                new StatsSwimmingstyleEntities(3)
                {
                    Id = 2,
                    Endurance = 3,
                    Technique = 4,
                    Difficulty = 3,
                    SwimmingStyleEntitiesId = 1,
                },
                 new StatsSwimmingstyleEntities(4)
                 {
                     Id = 3,
                     Endurance = 4,
                     Technique = 4,
                     Difficulty = 4,
                     SwimmingStyleEntitiesId = 2,
                 },
                new StatsSwimmingstyleEntities(5)
                {
                    Id = 4,
                    Endurance = 5,
                    Technique = 5,
                    Difficulty = 5,
                    SwimmingStyleEntitiesId = 2,
                });
            base.OnModelCreating(modelBuilder);
        }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             //optionsBuilder.UseNpgsql("Server=localhost,1433;Database=SwimmingStyleDb;User Id=sa;Password=yourStrong(!)Password;");
             optionsBuilder.UseSqlite("Data Source=SwimmingStyleDb.db");
             base.OnConfiguring(optionsBuilder);
         }*/
    }
}
