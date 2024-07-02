using GymBrosTracker.Domain.Models.Entity;
using GymBrosTracker.Domain.Repos.Interface;
using GymBrosTracker.UI.ViewModels.Base;
using System.Collections.ObjectModel;

namespace GymBrosTracker.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IGymRepo _gymRepo;

        public ObservableCollection<Exercise> Exercises { get; set; } = [];

        public MainViewModel(IGymRepo gymRepo)
        {
            _gymRepo = gymRepo;
            Task.Run(async () => await LoadDataAsync());
        }

        private async Task LoadDataAsync()
        {
            Exercises = new ObservableCollection<Exercise>(await _gymRepo.GetExercises());
        }
    }
}
