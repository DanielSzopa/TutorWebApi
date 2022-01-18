using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace TutorWebApi.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
