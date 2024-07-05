using GymBrosTracker.Domain;
using GymBrosTracker.UI.Installers;
using GymBrosTracker.UI.Services.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GymBrosTracker.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"));

            builder.Services.AddMauiBlazorWebView();

            builder.ConfigureLogging();

            Log.Logger.Information("Starting application");
            try
            {
                builder.RegisterServices();

                builder.Services.AddBlazorWebViewDeveloperTools();
                builder.Logging.AddDebug();

                var app = builder.Build();

                Log.Logger.Information("Application has been started");
                return app;
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, "Application terminated unexpectedly");
                throw;
            }
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddDomain();
            builder.Services.AddAuthorizationCore();
            builder.Services.TryAddScoped<AuthenticationStateProvider, ExternalAuthStateProvider>();

            return builder;
        }
    }
}
