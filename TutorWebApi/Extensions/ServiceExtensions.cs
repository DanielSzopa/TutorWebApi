using Microsoft.EntityFrameworkCore;
using TutorWebApi.Infrastructure;

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
    }
}
