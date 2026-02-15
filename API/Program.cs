using Microsoft.EntityFrameworkCore;
using Persistence;
using Application; // <- necessario per AssemblyReference
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configura il DbContext con Postgres
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// --- CORS ---
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// --- AutoMapper ---
builder.Services.AddAutoMapper(typeof(AssemblyReference).Assembly);

// --- MediatR ---
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
    
var app = builder.Build();

// --- Middleware CORS ---
app.UseCors();

// --- Middleware routing / controllers ---
app.MapControllers();

// --- Seed dati in Development ---
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await DbInitializer.SeedAsync(context);
}

app.Run();