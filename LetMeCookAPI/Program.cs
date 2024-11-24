using Microsoft.EntityFrameworkCore;

using LetMeCookAPI.Data;
using LetMeCookAPI.Services;
using LetMeCookAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33))
    ));

// Repositorios y Servicios
builder.Services.AddScoped<RecipeRepository>();
builder.Services.AddScoped<RecipesService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UsersService>();

// Controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
