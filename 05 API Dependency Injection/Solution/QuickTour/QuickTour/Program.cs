using QuickTour.Configuration;
using QuickTour.Middleware;
using QuickTour.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductsContext, MockProductsContext>();
builder.Services.AddTransient<ITransient, TransientDependency>();
builder.Services.AddScoped<IScoped, ScopedDependency>();
builder.Services.AddSingleton<ISingleton, SingletonDependency>();
builder.Services.AddTransient<IActionInjection, ActionInjectionDependency>();
builder.Services.Configure<FeaturesConfiguration>(builder.Configuration.GetSection("Features"));

Microsoft.Extensions.Configuration.ConfigurationManager config = builder.Configuration;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<CustomMiddleware1>();
app.UseMiddleware<CustomMiddleware2>();

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine(config["Message"]);
Console.ForegroundColor = ConsoleColor.White;


app.MapControllers();

app.Run();
