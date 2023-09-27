using Recipes.Models.Ingredient;
using Recipes.Models.Users;
using System.Text.Json.Serialization;

namespace Recipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<IngredientWithQuantity> Ingredients { get; set; }

        public string Description { get; set; }

        public string CreatorUsername { get; set; }

        public User Creator { get; set; }
    }
}
