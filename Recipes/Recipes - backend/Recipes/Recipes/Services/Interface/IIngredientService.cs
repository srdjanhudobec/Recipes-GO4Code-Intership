using Recipes.DTOs.Delete;
using Recipes.DTOs.Get.Ingredient;
using Recipes.DTOs.Post.Ingredient;

namespace Recipes.Services.Interface
{
    public interface IIngredientService
    {
        public List<IngredientGetResponse> getAllIngredients();

        public IngredientPostResponse createIngredient(IngredientPostRequest ingredient);

        public IngredientDeleteResponse deleteIngredient(string name);
    }
}
