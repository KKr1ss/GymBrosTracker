using GymBrosTracker.Domain.Helpers.Extensions;
using GymBrosTracker.Domain.Models.Entity;
using GymBrosTracker.Domain.Repos.Interface;
using GymBrosTracker.UI.ViewModels.Base;
using System.Collections.ObjectModel;

namespace GymBrosTracker.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IRepository _repo;

        public ObservableCollection<Exercise> Exercises { get; set; } = [];

        public MainViewModel(IRepository repo)
        {
            _repo = repo;
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                await _repo.SeedData();

                var exercises = await _repo.GetExercises();
                Exercises = new ObservableCollection<Exercise>(exercises);
                var muscleGroups = await _repo.GetMuscleGroups();
            }
            catch (Exception ex)
            {
                throw;
            }
            
            
        }
    }
}
