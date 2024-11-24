using Microsoft.AspNetCore.Components.Web;

namespace LetMeCookAPI.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public bool IsPublic { get; set; }
        public int UserId { get; set; }
    }
}
