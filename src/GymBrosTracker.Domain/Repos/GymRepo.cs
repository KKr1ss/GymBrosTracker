using GymBrosTracker.Domain.Data.Interface;
using GymBrosTracker.Domain.Models.Entity;
using GymBrosTracker.Domain.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace GymBrosTracker.Domain.Repos
{
    public class GymRepo(IAppDBContext dBContext) : IGymRepo
    {
        private readonly IAppDBContext _dbContext = dBContext;

        public async Task<IEnumerable<Exercise>> GetExercises(List<int>? muscleIds = null)
        {
            if (muscleIds != null)
                return await _dbContext.Exercises.Where(e => muscleIds.Contains(e.Id)).ToListAsync();
            return await _dbContext.Exercises.ToListAsync();
        }
    }
}
