using Microsoft.EntityFrameworkCore;

namespace Challenge.Models
{
    public class PlantContext : DbContext
    {
        public PlantContext(DbContextOptions<PlantContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlantContext>()
                .HasMany(c => c.Plants);

            modelBuilder.Seed();
        }

        public DbSet<Plant> Plants { get; set; }

    }
}
