using AutoMapper;
using Recipes.DTOs.Delete;
using Recipes.DTOs.Get.Ingredient;
using Recipes.DTOs.Post.Ingredient;
using Recipes.DTOs.Post.User;
using Recipes.Models;
using Recipes.Models.Ingredient;
using Recipes.Models.Users;
using Recipes.Repositorys.Interface;
using Recipes.Services.Interface;

namespace Recipes.Services.Service
{
    public class IngredientService:IIngredientService
    {
        public readonly IIngredientRepository _ingredients;
        public readonly IMapper _mapper;

        public IngredientService(IIngredientRepository ingredients, IMapper mapper)
        {
            _ingredients = ingredients;
            _mapper = mapper;
        }

        public IngredientPostResponse createIngredient(IngredientPostRequest ingredient)
        {
            var response = _mapper.Map<IngredientPostResponse>(_ingredients.createIngredient(_mapper.Map<Ingredient>(ingredient)));
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public IngredientDeleteResponse deleteIngredient(string name)
        {
            var response = _mapper.Map<IngredientDeleteResponse>(_ingredients.deleteIngredient(name));
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public List<IngredientGetResponse> getAllIngredients()
        {
            var response = _mapper.Map<List<IngredientGetResponse>>(_ingredients.getAllIngredients());
            if (response == null)
            {
                return null;
            }
            return response;
        }
    }
}
