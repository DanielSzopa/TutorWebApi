using Microsoft.Extensions.DependencyInjection;
using TutorWebApi.Domain;

namespace TutorWebApi.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IProfilRepository,ProfilRepository>();

            return services;
        }
    }
}
