using Recipes.Models;
using Recipes.Models.Ingredient;

namespace Recipes.Repositorys.Interface
{
    public interface IIngredientRepository
    {
        public Ingredient createIngredient(Ingredient ingredient);

        public List<Ingredient> getAllIngredients();

        public Ingredient deleteIngredient(string name);
    }
}
