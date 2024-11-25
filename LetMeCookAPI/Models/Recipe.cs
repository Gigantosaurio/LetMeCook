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
        public Recipe() { }
        public Recipe(string title, string description, string ingredients, string steps, bool isPublic, int userId)
        {
            Title = title;
            Description = description;
            Ingredients = ingredients;
            Steps = steps;
            IsPublic = isPublic;
            UserId = userId;
        }
        public Recipe(int id, string title, string description, string ingredients, string steps, bool isPublic, int userId)
        {
            Id = id;
            Title = title;
            Description = description;
            Ingredients = ingredients;
            Steps = steps;
            IsPublic = isPublic;
            UserId = userId;
        }
    }
}


//5000:80;
//9000:80;