using GymBrosTracker.Domain;
using GymBrosTracker.UI.ViewModels;
using Microsoft.Extensions.Logging;

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

    //        Log.Logger = new LoggerConfiguration()
    //.WriteTo.SQLite(Domain.Helpers.Constants.DBPath)
    //.CreateLogger();


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
