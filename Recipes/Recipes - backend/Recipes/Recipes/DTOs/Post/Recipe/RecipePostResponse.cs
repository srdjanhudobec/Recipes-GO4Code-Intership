using Recipes.Models.Ingredient;

namespace Recipes.DTOs.Post.Recipe
{
    public class RecipePostResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<IngredientWithQuantityPostDTO> Ingredients { get; set; }

        public string Description { get; set; }

        public string CreatorUsername { get; set; }
    }
}
