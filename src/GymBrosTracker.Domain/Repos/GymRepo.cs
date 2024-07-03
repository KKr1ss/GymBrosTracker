using GymBrosTracker.Domain.Data;
using GymBrosTracker.Domain.Data.Interface;
using GymBrosTracker.Domain.Helpers.Exceptions;
using GymBrosTracker.Domain.Models.Entity;
using GymBrosTracker.Domain.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace GymBrosTracker.Domain.Repos
{
    public class GymRepo(AppDBContext dBContext) : IGymRepo
    {
        private readonly AppDBContext _context = dBContext;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercise>> GetExercises(List<int>? muscleIds = null)
        {
            if (muscleIds != null)
                return await _context.Exercises.Where(e => muscleIds.Contains(e.Id)).ToListAsync();
            return await _context.Exercises.ToListAsync();
        }

        public async Task AddMuscleGroup(string name)
        {
            var muscleGroups = _context.MuscleGroups.Select(x => x.Name).ToArray();
            if (muscleGroups.Contains(name))
                throw new AlreadyExistsException();

            var dateTimeNow = DateTime.Now;
            MuscleGroup muscleGroup = new()
            {
                Name = name,
                CreateDate = dateTimeNow,
                UpdateDate = dateTimeNow
            };
            await _context.MuscleGroups.AddAsync(muscleGroup);
        }

        public async Task<IEnumerable<MuscleGroup>> GetMuscleGroups()
        {
            return await _context.MuscleGroups.ToListAsync();
        }
    }
}
