using NewsService.Utils;
using NewsService.Services;

// load envs 
DotEnv.Load(".env");

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<NewsStoryService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

var app = builder.Build();

// Attach our AuthMiddleware
app.Use((context, next) => AuthService.Authorize(context, next));

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
