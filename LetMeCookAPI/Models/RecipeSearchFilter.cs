namespace LetMeCookAPI.Models{
    public class RecipeSearchFilter
    {
        public string? Keyword { get; set; }
        public bool SearchInTitle { get; set; }
        public bool SearchInIngredients { get; set; }
        public bool SearchInSteps { get; set; }
    }
}