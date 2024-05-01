using DotNetApp;
using DotNetApp.Core;
using DotNetApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.RegisterDependencyInitialization();
builder.Services.AddCore();
builder.Services.AddSwaggerGen();
builder.Services.ManualDependency();
builder.Services.AddBindings();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerAndRedocUi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.AddMiddlewares();

// Initialize database
await app.InitializeDatabase();

app.Run();