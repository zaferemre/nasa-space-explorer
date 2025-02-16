using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DotNetEnv;
using NasaExplorer.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Load environment variables from .env.local
Env.Load(".env.local");

builder.Services.AddControllers();
builder.Services.AddHttpClient<NasaService>();

// ✅ Allow CORS (Fixes 403)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Hello from NASA API!");

app.Run();
