using GymBrosTracker.Domain.Models.Entity;

namespace GymBrosTracker.Domain.Repos.Interface
{
    public interface IRepository
    {
        public Task SaveChangesAsync();

        public Task AddMuscleGroup(string name);
        public Task<IEnumerable<MuscleGroup>> GetMuscleGroups(List<int>? muscleIds = null);

        public Task AddExercise(Exercise exercise);
        public Task<IEnumerable<Exercise>> GetExercises(List<int>? muscleIds = null);
    }
}
