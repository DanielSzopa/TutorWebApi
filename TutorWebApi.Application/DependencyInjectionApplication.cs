using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TutorWebApi.Domain;

namespace TutorWebApi.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserContextService, UserContextService>();
            services.AddScoped<IUserService, UserService>();
            services.AddHttpContextAccessor();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddScoped<IResourceOperationService<Profile>, ResourceOperationService<Profile>>();
            services.AddScoped<IResourceOperationService<Address>, ResourceOperationService<Address>>();
            services.AddScoped<IResourceOperationService<User>, ResourceOperationService<User>>();
            services.AddScoped<IResourceOperationService<Comment>, ResourceOperationService<Comment>>();

            services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();
            services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddScoped<IValidator<AchievementDto>, AchievementDtoValidator>();
            services.AddScoped<IValidator<ExperienceDto>, ExperienceDtoValidator>();
            services.AddScoped<IValidator<AddressDto>, AddressDtoValidator>();
            services.AddScoped<IValidator<PersonalDto>, PersonalDtoValidator>();
            services.AddScoped<IValidator<CommentDto>, CommentDtoValidator>();

            return services;
        }
    }
}
