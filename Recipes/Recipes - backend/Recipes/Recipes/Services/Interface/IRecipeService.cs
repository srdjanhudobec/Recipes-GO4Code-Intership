using Recipes.DTOs;
using Recipes.DTOs.Delete;
using Recipes.DTOs.Get.Recipe;
using Recipes.DTOs.Post.Recipe;
using Recipes.Models;

namespace Recipes.Services.Interface
{
    public interface IRecipeService
    {
        public List<RecipesGetResponse> getAllRecipes();

        public RecipeDeleteResponse deleteRecipe(string name, string username);

        public RecipePostResponse createRecipe(RecipePostRequest recipe,string username);

        public List<RecipesGetResponse> getSearchedRecipes(string name, string ingredientname);
    }
}
