using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Exceptions;

namespace GymBrosTracker.UI.Installers
{
    public static class Logging
    {
        /// <summary>
        /// Configure serilog
        /// </summary>
        public static MauiAppBuilder ConfigureLogging(this MauiAppBuilder builder)
        {
            builder.Logging.ClearProviders();
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithExceptionDetails()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(Domain.Helpers.Constants.LogPath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            builder.Services.AddLogging(logging => logging.AddSerilog(dispose: true));

            return builder;
        }
    }
}
