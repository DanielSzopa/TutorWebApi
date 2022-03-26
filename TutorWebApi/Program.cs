using TutorWebApi.Application;
using TutorWebApi.Extensions;
using TutorWebApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.AddNlog();
builder.Services.AddControllersExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddJwtAuthentication();
builder.Services.AddApplication();
builder.Services.AddTutorWebApiServices();
builder.Services.AddInfrastructure();
builder.Services.AddConfigureRouting();
builder.Services.AddCorsExtension();
builder.AddContext();

var app = builder.Build();
app.UseCors("Client");
await app.SeedData();
if (app.Environment.IsDevelopment())
    app.UseSwaggerConfig();
app.AddMiddleware();
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }
