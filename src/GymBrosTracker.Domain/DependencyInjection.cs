using GymBrosTracker.Domain.Data;
using GymBrosTracker.Domain.Repos;
using GymBrosTracker.Domain.Repos.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace GymBrosTracker.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDBContext>();
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
