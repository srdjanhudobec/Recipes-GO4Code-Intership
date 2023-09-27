using AutoMapper;
using Recipes.DTOs;
using Recipes.DTOs.Delete;
using Recipes.DTOs.Get.Ingredient;
using Recipes.DTOs.Post.Ingredient;
using Recipes.Models.Ingredient;

namespace Recipes.Profiles
{
    public class IngredientProfile:Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientGetResponse>();
            CreateMap<IngredientGetResponse, Ingredient>();
            CreateMap<IngredientPostRequest, Ingredient>();
            CreateMap<Ingredient, IngredientPostRequest>();
            CreateMap<IngredientPostResponse, Ingredient>();
            CreateMap<Ingredient    , IngredientPostResponse>();
            CreateMap<Ingredient, IngredientDeleteResponse>();
            CreateMap<IngredientDeleteResponse, Ingredient>();
            CreateMap<IngredientWithQuantity, IngredientDTO>();
            CreateMap<IngredientDTO, IngredientWithQuantity>();
        }
    }
}
