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
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var exercises = await _gymRepo.GetExercises();
                Exercises = new ObservableCollection<Exercise>(exercises);
            }
            catch (Exception ex)
            {
                throw;
            }
            
            
        }
    }
}
