using GymBrosTracker.Domain.Helpers.Extensions;
using GymBrosTracker.Domain.Models.Entity;
using GymBrosTracker.Domain.Repos.Interface;
using GymBrosTracker.UI.ViewModels.Base;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace GymBrosTracker.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IRepository _repo;
        private readonly ILogger<MainViewModel> _logger;

        public ObservableCollection<Exercise> Exercises { get; set; } = [];

        public MainViewModel(IRepository repo, ILogger<MainViewModel> logger)
        {
            _repo = repo;
            _logger = logger;
            Task.Run(async () => await LoadDataAsync());
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var exercises = await _repo.GetExercises();
                if (!exercises.Any())
                    await _repo.SeedData();

                Exercises = new ObservableCollection<Exercise>(exercises);
                var muscleGroups = await _repo.GetMuscleGroups();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR: ");
            }
        }
    }
}
