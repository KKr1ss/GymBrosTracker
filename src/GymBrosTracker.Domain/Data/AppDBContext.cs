using GymBrosTracker.Domain.Data.Interface;
using GymBrosTracker.Domain.Helpers;
using GymBrosTracker.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;

namespace GymBrosTracker.Domain.Data
{
    public class AppDBContext : DbContext, IAppDBContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;
            string dbPath = Constants.DBPath;
            optionsBuilder.UseSqlite($"Filename={dbPath}");
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>()
                .HasMany(e => e.MuscleGroups)
                .WithMany(e => e.Exercises)
                .UsingEntity("Exercise_MuscleGroup");
        }
    }
}
