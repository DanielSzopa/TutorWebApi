using TutorWebApi.Middleware;

namespace TutorWebApi
{
    public static class ApplicationExtensions
    {
        public static void UseSwaggerConfig(this WebApplication application)
        {
            application.UseSwagger();
            application.UseSwaggerUI();
        }

        public static void AddMiddleware(this WebApplication application)
        {
            application.UseMiddleware<ErrorHandlingMiddleware>();
        }

        public static async Task SeedData(this WebApplication application)
        {
            var scope = application.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<TutorWebApiSeeder>();

            await seeder.Seed();
        }
    }
}
