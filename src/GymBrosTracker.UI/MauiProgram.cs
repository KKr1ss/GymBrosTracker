using Microsoft.Extensions.Logging;
using GymBrosTracker.Domain;
using GymBrosTracker.UI.ViewModels;
using GymBrosTracker.Domain.Repos.Interface;
using GymBrosTracker.Domain.Repos;

namespace GymBrosTracker.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            
            builder.RegisterServices();
            builder.RegisterViewModels();
            builder.RegisterViews();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddDomain();

            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<MainViewModel>();

            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<MainPage>();

            return builder;
        }

    }
}
