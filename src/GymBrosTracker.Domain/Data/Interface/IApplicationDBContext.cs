using GymBrosTracker.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace GymBrosTracker.Domain.Data.Interface
{
    public interface IApplicationDBContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        public Task SaveChangesAsync();
    }
}
