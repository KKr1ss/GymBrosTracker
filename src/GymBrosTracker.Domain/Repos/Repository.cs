using GymBrosTracker.Domain.Data;
using GymBrosTracker.Domain.Helpers.Exceptions;
using GymBrosTracker.Domain.Models.Entity;
using GymBrosTracker.Domain.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace GymBrosTracker.Domain.Repos
{
    public class Repository(ApplicationDBContext dBContext) : IRepository
    {
        private readonly ApplicationDBContext _context = dBContext;

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
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

        public async Task<IEnumerable<MuscleGroup>> GetMuscleGroups(List<int>? muscleIds = null)
        {
            if (muscleIds != null)
                return await _context.MuscleGroups.Where(e => muscleIds.Contains(e.Id)).ToListAsync();
            return await _context.MuscleGroups.ToListAsync();
        }

        public async Task AddExercise(Exercise exercise)
        {
            var exercises = _context.Exercises.Select(x => x.Name).ToArray();
            if (exercises.Contains(exercise.Name))
                throw new AlreadyExistsException();

            var dateTimeNow = DateTime.Now;
            exercise.CreateDate = dateTimeNow;
            exercise.UpdateDate = dateTimeNow;

            var muscleGroups = await GetMuscleGroups(exercise.MuscleGroups.Select(x=>x.Id).ToList());
            exercise.MuscleGroups = muscleGroups.ToList();
           
            await _context.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercise>> GetExercises(List<int>? muscleIds = null)
        {
            if (muscleIds != null)
                return await _context.Exercises.Where(e => muscleIds.Contains(e.Id)).ToListAsync();
            return await _context.Exercises.ToListAsync();
        }
    }
}
