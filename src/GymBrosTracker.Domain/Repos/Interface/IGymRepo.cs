using GymBrosTracker.Domain.Helpers.Exceptions;
using GymBrosTracker.Domain.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace GymBrosTracker.Domain.Repos.Interface
{
    public interface IGymRepo
    {
        public Task SaveChangesAsync();
        public Task<IEnumerable<Exercise>> GetExercises(List<int>? muscleIds = null);

        public Task AddMuscleGroup(string name);

        public Task<IEnumerable<MuscleGroup>> GetMuscleGroups();
    }
}
