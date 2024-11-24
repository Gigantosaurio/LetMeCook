using Microsoft.AspNetCore.Mvc;
using LetMeCookAPI.Models;
using LetMeCookAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly RecipesService _service;

    public RecipesController(RecipesService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetPublicRecipes()
    {
        var recipes = _service.GetPublicRecipes();
        return Ok(recipes);
    }

    [HttpPost]
    public IActionResult CreateRecipe([FromBody] Recipe recipe)
    {
        var createdRecipe = _service.CreateRecipe(recipe);
        return CreatedAtAction(nameof(GetPublicRecipes), new { id = createdRecipe.Id }, createdRecipe);
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchRecipes([FromBody] RecipeSearchFilter filter)
    {
        var recipes = await _service.SearchRecipes(filter);
        return Ok(recipes);
    }

}
