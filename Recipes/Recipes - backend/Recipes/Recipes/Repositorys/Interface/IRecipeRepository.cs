using Recipes.Models;

namespace Recipes.Repositorys.Interface
{
    public interface IRecipeRepository
    {
        public Recipe createRecipe(Recipe recipe,string username);

        public Recipe deleteRecipe(string name,string username);

        public List<Recipe> getAllRecipes();

        public List<Recipe> getSearchedRecipes(string name, string ingredientname);
    }
}
