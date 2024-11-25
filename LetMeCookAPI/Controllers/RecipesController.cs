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
    public IActionResult GetAll()
    {
        var recipes = _service.GetAll();
        return Ok(recipes);
    }

    [HttpPost]
    public IActionResult CreateRecipe([FromBody] Recipe recipe)
    {
        var createdRecipe = _service.CreateRecipe(recipe);
        return CreatedAtAction(nameof(GetAll), new { id = createdRecipe.Id }, createdRecipe);
    }

    [HttpPost("search")]
    public async Task<IActionResult> SearchRecipes([FromBody] RecipeSearchFilter filter)
    {
        var recipes = await _service.SearchRecipes(filter);
        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public IActionResult GetRecipeById(int id)
    {
        var recipe = _service.GetRecipeById(id);
        return Ok(recipe);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRecipe(int id)
    {
        _service.DeleteRecipe(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRecipe(int id, [FromBody] Recipe recipe)
    {
        var updatedRecipe = _service.UpdateRecipe(recipe);
        return Ok(updatedRecipe);
    }

    [HttpGet("public")]
    public IActionResult GetPublicRecipes()
    {
        var recipes = _service.GetPublicRecipes();
        return Ok(recipes);
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetRecipesByUser(int userId)
    {
        var recipes = _service.GetRecipesByUser(userId);
        return Ok(recipes);
    }

}
