using Microsoft.EntityFrameworkCore;
using LetMeCookAPI.Models;

namespace LetMeCookAPI.Data;
public class AppDbContext : DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
}
