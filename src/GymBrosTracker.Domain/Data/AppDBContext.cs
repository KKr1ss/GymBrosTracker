using GymBrosTracker.Domain.Helpers;
using GymBrosTracker.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace GymBrosTracker.Domain.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        public AppDBContext()
        {
            SQLitePCL.Batteries_V2.Init();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                if (optionsBuilder.IsConfigured)
                    return;
                string dbPath = Constants.DBPath;
                optionsBuilder.UseSqlite($"Filename={dbPath}");
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.MuscleGroups)
                .WithMany(e => e.Exercises)
                .UsingEntity("Exercise_MuscleGroup");

            modelBuilder.Entity<MuscleGroup>().Property(o => o.RowVersion)
                    .IsRowVersion()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
