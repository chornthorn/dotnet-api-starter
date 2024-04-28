using DotNetApp;
using DotNetApp.Core;
using DotNetApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.InitializeAutoDependency();
builder.Services.AddCore();
builder.Services.AddSecurity();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerAndRedocUi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.AddMiddlewares();

app.Run();