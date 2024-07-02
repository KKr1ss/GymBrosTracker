using GymBrosTracker.Domain.Models.Entity;

namespace GymBrosTracker.Domain.Repos.Interface
{
    public interface IGymRepo
    {
        public Task<IEnumerable<Exercise>> GetExercises(List<int>? muscleIds = null);
    }
}
