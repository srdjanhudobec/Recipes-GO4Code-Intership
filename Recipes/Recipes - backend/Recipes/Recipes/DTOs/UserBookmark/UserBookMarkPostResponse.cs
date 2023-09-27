using Recipes.Models.Users;
using Recipes.Models;

namespace Recipes.DTOs.UserBookmark
{
    public class UserBookMarkPostResponse
    {
        public int Id { get; set; }

        public string UserUsername { get; set; }

        public int UserId { get; set; }


        public string RecipeName { get; set; }

        public int RecipeId { get; set; }

    }
}
