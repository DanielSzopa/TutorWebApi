using NLog.Web;
using TutorWebApi;
using TutorWebApi.Application;
using TutorWebApi.Infrastructure;
using TutorWebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNLog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddTutorWebApiServices();

builder.AddContext();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwaggerConfig();

app.AddMiddleware();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
