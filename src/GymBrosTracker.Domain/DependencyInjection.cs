using GymBrosTracker.Domain.Data;
using GymBrosTracker.Domain.Data.Interface;
using GymBrosTracker.Domain.Repos;
using GymBrosTracker.Domain.Repos.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace GymBrosTracker.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<AppDBContext>();
            services.AddTransient<IGymRepo, GymRepo>();

            return services;
        }
    }
}
