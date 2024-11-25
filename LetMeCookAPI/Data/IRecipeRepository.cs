using LetMeCookAPI.Models;

public interface IRecipeRepository
{
    IEnumerable<Recipe> GetAll();
    IEnumerable<Recipe> GetAllPublic();
    IEnumerable<Recipe> GetAllByUser(int userId);
    Recipe Get(int id);
    Recipe Add(Recipe recipe);
    
    int Delete(Recipe recipe);
    Recipe Update(Recipe recipe);

    IQueryable<Recipe> GetAllQueryable();
}
