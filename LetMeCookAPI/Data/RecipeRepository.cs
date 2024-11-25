using LetMeCookAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace LetMeCookAPI.Data;

public class RecipeRepository : IRecipeRepository
{
    private readonly AppDbContext _context;

    public RecipeRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Recipe> GetAllPublic()
    {
        return _context.Recipes.Where(r => r.IsPublic).ToList();
    }

    public Recipe Add(Recipe recipe)
    {
        _context.Recipes.Add(recipe);
        _context.SaveChanges();
        return recipe;
    }

    public Recipe Get(int id)
    {
        return _context.Recipes.FirstOrDefault(r => r.Id == id);
    }

    public int Delete(Recipe recipe)
    {
        _context.Recipes.Remove(recipe);
        _context.SaveChanges();
        return recipe.Id;
    }

    public Recipe Update(Recipe recipe)  
    {
        _context.Recipes.Update(recipe);
        _context.SaveChanges();
        return recipe;
    }

    public IEnumerable<Recipe> GetAll()
    {
        return _context.Recipes.ToList();
    }

    public IEnumerable<Recipe> GetAllByUser(int userId)
    {
        return _context.Recipes.Where(r => r.UserId == userId).ToList();
    }

    public IQueryable<Recipe> GetAllQueryable()
    {
        return _context.Recipes.AsQueryable();
    }
}
