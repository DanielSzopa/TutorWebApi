using Microsoft.EntityFrameworkCore;
using TutorWebApi.Infrastructure;
using TutorWebApi.Middleware;

namespace TutorWebApi
{
    public static class ServiceExtensions
    {
        public static WebApplicationBuilder AddContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TutorWebApiDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), a => a.MigrationsAssembly("TutorWebApi")));

            return builder;
        }

        public static IServiceCollection AddTutorWebApiServices(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
            return services;
        }
    }
}
