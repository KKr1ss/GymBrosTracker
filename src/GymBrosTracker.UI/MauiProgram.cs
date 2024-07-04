using GymBrosTracker.Domain;
using Microsoft.Extensions.Logging;
using Serilog;
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
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Logging.ClearProviders();
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithExceptionDetails()
                .Enrich.FromLogContext()
                .WriteTo.SQLite(Domain.Helpers.Constants.DBPath)
                .CreateLogger();
            builder.Services.AddLogging(logging =>
            {
                logging.AddSerilog(dispose: true);
            });

            builder.RegisterServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            Log.Logger.Information("Application has been started!");
            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddDomain();

            return builder;
        }
    }
}
