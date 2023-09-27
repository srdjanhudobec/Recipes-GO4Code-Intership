using Recipes.Models.Ingredient;

namespace Recipes.DTOs
{
    public class RecipesGetResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<IngredientDTO> Ingredients { get; set; }

        public string Description { get; set; }

        public string CreatorUsername { get; set; }
    }
}
