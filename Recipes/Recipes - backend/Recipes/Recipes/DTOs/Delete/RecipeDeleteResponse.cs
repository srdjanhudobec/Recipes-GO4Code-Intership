using Recipes.Models.Ingredient;
using Recipes.Models.Users;

namespace Recipes.DTOs.Delete
{
    public class RecipeDeleteResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<IngredientWithQuantity> Ingredients { get; set; }

        public string Description { get; set; }

        public string CreatorUsername { get; set; }

    }
}
