using AutoMapper;
using Recipes.DTOs;
using Recipes.DTOs.Delete;
using Recipes.DTOs.Get.Recipe;
using Recipes.DTOs.Post.Recipe;
using Recipes.Models;
using Recipes.Models.Ingredient;
using Recipes.Models.Users;
using Recipes.Repositorys.Interface;
using Recipes.Services.Interface;

namespace Recipes.Services.Service
{
    public class RecipeService:IRecipeService
    {
        public readonly IRecipeRepository _recipes;
        public readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipes, IMapper mapper)
        {
            _recipes = recipes;
            _mapper = mapper;
        }

        public RecipePostResponse createRecipe(RecipePostRequest recipe,string username)
        {
            //_mapper.Map<IngredientWithQuantity>(recipe.Ingredients);
            var response = _mapper.Map<RecipePostResponse>(_recipes.createRecipe(_mapper.Map<Recipe>(recipe),username));
            if(response == null)
            {
                return null;
            }
            return response;
        }

        public RecipeDeleteResponse deleteRecipe(string name, string username)
        {
            var response = _mapper.Map<RecipeDeleteResponse>(_recipes.deleteRecipe(name, username));
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public List<RecipesGetResponse> getAllRecipes()
        {
            var response = _mapper.Map<List<RecipesGetResponse>>(_recipes.getAllRecipes());
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public List<RecipesGetResponse> getSearchedRecipes(string name, string ingredientname)
        {
            var response = _mapper.Map<List<RecipesGetResponse>>(_recipes.getSearchedRecipes(name,ingredientname));
            if (response == null)
            {
                return null;
            }
            return response;
        }
    }
}
