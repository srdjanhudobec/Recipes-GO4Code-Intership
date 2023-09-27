using Recipes.Models.Users;

namespace Recipes.Models
{
    public class UserBookmark
    {
        public int Id { get; set; }
        
        public string UserUsername { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string RecipeName { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

    }
}
