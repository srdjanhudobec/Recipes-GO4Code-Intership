using AutoMapper;
using Recipes.DTOs;
using Recipes.DTOs.Delete;
using Recipes.DTOs.Get.Ingredient;
using Recipes.DTOs.Get.Recipe;
using Recipes.DTOs.Post.Ingredient;
using Recipes.DTOs.Post.Recipe;
using Recipes.Models;
using Recipes.Models.Ingredient;

namespace Recipes.Profiles
{
    public class RecipeProfile:Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeGetResponse>();
            CreateMap<RecipeGetResponse, Recipe>();
            CreateMap<IngredientWithQuantityPostDTO, IngredientWithQuantity>();
            CreateMap<IngredientWithQuantity, IngredientWithQuantityPostDTO>();
            CreateMap<RecipePostRequest, Recipe>();
            CreateMap<Recipe, RecipePostRequest>();
            CreateMap<RecipePostResponse, Recipe>();
            CreateMap<Recipe, RecipePostResponse>();
            CreateMap<Recipe, RecipeDeleteResponse>();
            CreateMap<RecipeDeleteResponse, Recipe>();
            CreateMap<RecipesGetResponse, Recipe>();
            CreateMap<Recipe, RecipesGetResponse>();
            CreateMap<Ingredient, IngredientWithQuantity>();
            CreateMap<IngredientWithQuantity, Ingredient>();
        }
    }
}
