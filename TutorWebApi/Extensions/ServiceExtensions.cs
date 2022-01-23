using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TutorWebApi.Application;
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
            services.AddScoped<IAuthorizationHandler, ResourceOperationRequirementHandlerProfil>();
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
    }
}
