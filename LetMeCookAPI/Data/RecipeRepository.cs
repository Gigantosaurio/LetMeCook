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
        throw new NotImplementedException();
    }

    public int Delete(Recipe recipe)
    {
        throw new NotImplementedException();
    }

    public int Update(Recipe recipe)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Recipe> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Recipe> GetAllByUser(int userId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Recipe> seachByFilters(string title, string description)
    {
        throw new NotImplementedException();
    }
    public IQueryable<Recipe> GetAllQueryable()
    {
        return _context.Recipes.AsQueryable();
    }
}
