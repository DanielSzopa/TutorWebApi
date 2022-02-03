﻿using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TutorWebApi.Application.Authorization;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Account;
using TutorWebApi.Application.Models.Comment;
using TutorWebApi.Application.Models.Profile;
using TutorWebApi.Application.Models.User;
using TutorWebApi.Application.Services;
using TutorWebApi.Application.Validators.Account;
using TutorWebApi.Application.Validators.Comment;
using TutorWebApi.Application.Validators.Profile;
using TutorWebApi.Application.Validators.User;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Domain.Interfaces;

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
           // services.AddScoped<IUserContextService, UserContextService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IAchievementService, AchievementService>();
            services.AddHttpContextAccessor();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddScoped<IResourceOperationService<Profile>, ResourceOperationService<Profile>>();
            services.AddScoped<IResourceOperationService<Address>, ResourceOperationService<Address>>();
            services.AddScoped<IResourceOperationService<User>, ResourceOperationService<User>>();
            services.AddScoped<IResourceOperationService<Comment>, ResourceOperationService<Comment>>();
            services.AddScoped<IResourceOperationService<Like>, ResourceOperationService<Like>>();
            services.AddScoped<IResourceOperationService<Achievement>, ResourceOperationService<Achievement>>();
            services.AddScoped<IResourceOperationService<Experience>, ResourceOperationService<Experience>>();

            services.AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>();
            services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();
            services.AddScoped<IValidator<AchievementDto>, AchievementDtoValidator>();
            services.AddScoped<IValidator<ExperienceDto>, ExperienceDtoValidator>();
            services.AddScoped<IValidator<AddressDto>, AddressDtoValidator>();
            services.AddScoped<IValidator<PersonalDto>, PersonalDtoValidator>();
            services.AddScoped<IValidator<NewCommentDto>, CommentDtoValidator>();
            services.AddScoped<IValidator<ChangePasswordRequestDto>, ChangePasswordRequestDtoValidator>();

            return services;
        }
    }
}
