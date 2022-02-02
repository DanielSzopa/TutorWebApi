using Microsoft.Extensions.DependencyInjection;
using TutorWebApi.Domain.Interfaces;
using TutorWebApi.Infrastructure.Repositories;
using TutorWebApi.Infrastructure.Seeder;

namespace TutorWebApi.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IProfileRepository,ProfileRepository>();
            services.AddScoped<ICommentRepository,CommentRepository>();
            services.AddScoped<ILikeRepository,LikeRepository>();
            services.AddScoped<IAchievementRepository,AchievementRepository>();
            services.AddScoped<IExperienceRepository,ExperienceRepository>();

            services.AddScoped<TutorWebApiSeeder>();

            return services;
        }
    }
}
