using Recipes.Models.Ingredient;

namespace Recipes.DTOs.Post.Recipe
{
    public class RecipePostRequest
    {

        public string Name { get; set; }

        public List<IngredientWithQuantityPostDTO> Ingredients { get; set; }

        public string Description { get; set; }

    }
}
