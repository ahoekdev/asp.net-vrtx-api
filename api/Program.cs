using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Repositories;
using api.Services;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    // Postgres doesn't handle PascalCase columns so wel, so entity names are converted to snake_case
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());

builder.Services.AddControllers(options =>
{
    // Converts JSON response to use camelCase naming convention instead of PascalCase
    options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
}).AddJsonOptions(options =>
{
    // Convert enum values (which are usually integers) to strings in JSON responses
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Register services
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
