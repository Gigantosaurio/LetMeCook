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
    public IEnumerable<Recipe> GetPublicRecipes()
    {
        return _repository.GetAllPublic();
    }
    public Recipe CreateRecipe(Recipe recipe)
    {
        return _repository.Add(recipe);
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