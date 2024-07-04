using GymBrosTracker.Domain;
using GymBrosTracker.UI.ViewModels;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Exceptions;

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

            builder.Logging.ClearProviders();
            //Log.Logger = new LoggerConfiguration()
            //    .Enrich.WithExceptionDetails()
            //    .Enrich.FromLogContext()
            //    .WriteTo.SQLite(Domain.Helpers.Constants.DBPath)
            //    .CreateLogger();
            builder.Services.AddLogging(logging =>
            {
                logging.AddSerilog(dispose: true);
            });

            builder.RegisterServices();
            builder.RegisterViewModels();
            builder.RegisterViews();
//#if DEBUG
//            builder.Logging.AddDebug();
//#endif
            Log.Logger.Information("Application has been started!");
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
