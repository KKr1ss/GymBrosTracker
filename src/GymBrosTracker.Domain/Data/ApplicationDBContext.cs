using GymBrosTracker.Domain.Helpers;
using GymBrosTracker.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace GymBrosTracker.Domain.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        public ApplicationDBContext()
        {
            SQLitePCL.Batteries_V2.Init();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;
            string dbPath = Constants.DBPath;
            optionsBuilder.UseSqlite($"Filename={dbPath}");
            optionsBuilder.EnableSensitiveDataLogging();
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

            modelBuilder.Entity<Exercise>().Property(o => o.RowVersion)
                    .IsRowVersion()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Image>().Property(o => o.RowVersion)
                    .IsRowVersion()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Workout>().Property(o => o.RowVersion)
                    .IsRowVersion()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
