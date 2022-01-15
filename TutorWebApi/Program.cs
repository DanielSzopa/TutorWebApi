using TutorWebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddContext();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwaggerConfig();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
