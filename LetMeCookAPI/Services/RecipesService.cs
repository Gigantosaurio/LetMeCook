using LetMeCookAPI.Models;
using LetMeCookAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LetMeCookAPI.Services;
public class RecipesService
{
    private readonly RecipeRepository _repository;
    public RecipesService(RecipeRepository repository)
    {
        _repository = repository;
    }
    public IEnumerable<Recipe> GetAll()
    {
        return _repository.GetAll();
    }
    public IEnumerable<Recipe> GetPublicRecipes()
    {
        return _repository.GetAllPublic();
    }
    public Recipe CreateRecipe(Recipe recipe)
    {
        return _repository.Add(recipe);
    }

    public Recipe GetRecipeById(int id)
    {
        return _repository.Get(id);
    }

    public int DeleteRecipe(int id)
    {
        return _repository.Delete(_repository.Get(id));
    }

    public Recipe UpdateRecipe(Recipe recipe)
    {
        return _repository.Update(recipe);
    }

    public IEnumerable<Recipe> GetRecipesByUser(int userId)
    {
        return _repository.GetAllByUser(userId);
    }

    public async Task<IEnumerable<Recipe>> SearchRecipes(RecipeSearchFilter filter)
    {
        var query = _repository.GetAllQueryable();

        if (!string.IsNullOrEmpty(filter.Keyword))
        {
            // Aplica los filtros dinámicamente
            query = query.Where(recipe =>
                (filter.SearchInTitle && recipe.Title.Contains(filter.Keyword)) ||
                (filter.SearchInIngredients && recipe.Ingredients.Contains(filter.Keyword)) ||
                (filter.SearchInSteps && recipe.Steps.Contains(filter.Keyword)));
        }
        
        return await query.ToListAsync();
    }
}