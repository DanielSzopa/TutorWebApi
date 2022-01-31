using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NLog.Web;
using System.Text;
using TutorWebApi.Application.Authorization;
using TutorWebApi.Application.Models.Account;
using TutorWebApi.Domain.Entities;
using TutorWebApi.Infrastructure.Context;
using TutorWebApi.Middleware;
using TutorWebApi.Seeder;

namespace TutorWebApi.Extensions
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
            services.AddScoped<TutorWebApiSeeder>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandlerBase<Domain.Entities.Profile>>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandlerBase<Address>>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandlerBase<User>>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandlerBase<Comment>>();
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandlerBase<Like>>();
            return services;
        }

        public static WebApplicationBuilder AddJwtAuthentication(this WebApplicationBuilder builder)
        {
            var authenticationSettings = new AuthenticationSettings();
            builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });

            builder.Services.AddSingleton(authenticationSettings);
            return builder;
        }

        public static IServiceCollection AddControllersExtension(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation();

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            return services;
        }

        public static WebApplicationBuilder AddNlog(this WebApplicationBuilder builder)
        {
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
            return builder;
        }

        public static IServiceCollection AddConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            return services;
        }
    }
}
