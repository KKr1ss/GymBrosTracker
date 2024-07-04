using GymBrosTracker.UI.ViewModels;

namespace GymBrosTracker.UI
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        
    }

}
