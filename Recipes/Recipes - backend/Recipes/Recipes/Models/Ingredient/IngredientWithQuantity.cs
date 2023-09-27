namespace Recipes.Models.Ingredient
{
    public class IngredientWithQuantity
    {
        public int Id { get; set; }
        public int IngredientId { get; set; } 

        public string IngredientName { get; set; }

        public Ingredient Ingredient { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int Quantity { get; set; }

    }
}
