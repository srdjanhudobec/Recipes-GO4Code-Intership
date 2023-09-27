using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.DTOs.Delete;
using Recipes.DTOs.Get.Ingredient;
using Recipes.DTOs.Post.Ingredient;
using Recipes.Models;
using Recipes.Models.Ingredient;
using Recipes.Services.Interface;

namespace Recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IngredientController : ControllerBase
    {
        public readonly IIngredientService _ingredients;

        public IngredientController(IIngredientService ingredients)
        {
            _ingredients = ingredients;
        }

        /// <summary>
        /// Get all ingredients (can be done only by admin)
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-ingredients")]
        [Authorize(Roles = Roles.Admin)]

        public ActionResult<List<IngredientGetResponse>> getAllIngredients()
        {
            var response = _ingredients.getAllIngredients();
            if(response == null)
            {
                return NotFound("No ingredients found.");
            }
            return Ok(response);
        }
        /// <summary>
        /// Create ingredient (can be done only by admin)
        /// </summary>
        /// <param name="ingredient"></param>
        /// <returns></returns>
        [HttpPost("create-ingredient")]
        [Authorize(Roles = Roles.Admin)]

        public ActionResult<IngredientPostResponse> createIngredient(IngredientPostRequest ingredient)
        {
            var response = _ingredients.createIngredient(ingredient);
            if(response == null)
            {
                return BadRequest("Something went wrong, please try again. ");
            }
            return Ok(response);
        }
        /// <summary>
        /// Delete ingredient (can be done only by admin)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete("delete-ingredient")]
        [Authorize(Roles = Roles.Admin)]

        public ActionResult<IngredientDeleteResponse> deleteIngredient(string name)
        {
            var response = _ingredients.deleteIngredient(name);
            if (response == null)
            {
                return BadRequest("Something went wrong, please try again. ");
            }
            return Ok(response);
        }
    }
}
