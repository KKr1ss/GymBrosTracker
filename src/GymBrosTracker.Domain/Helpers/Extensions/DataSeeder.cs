using GymBrosTracker.Domain.Models.Entity;
using GymBrosTracker.Domain.Repos.Interface;

namespace GymBrosTracker.Domain.Helpers.Extensions
{
    public static class DataSeeder
    {
        public static async Task SeedData(this IRepository _repo)
        {
            await _repo.AddMuscleGroup("Mell");
            await _repo.AddMuscleGroup("Melsőváll");
            await _repo.AddMuscleGroup("Bicepsz");
            await _repo.AddMuscleGroup("Trinyó");

            await _repo.SaveChangesAsync();

            await _repo.AddExercise(new Exercise()
            {
                Name = "Fekvenyomás",
                Description = "Fekvő padon nyomás",
                MuscleGroups =
                [
                    new MuscleGroup {
                        Id = 1
                    },
                    new MuscleGroup
                    {
                        Id = 2
                    }
                ]
            });

            await _repo.AddExercise(new Exercise()
            {
                Name = "Kábeles lehúzás",
                Description = "Beállsz a kábelhez és húzod, stabil felsőkarral",
                MuscleGroups =
                [
                    new MuscleGroup {
                        Id = 3
                    }
                ]
            });

            await _repo.SaveChangesAsync();
        }
    }


}
