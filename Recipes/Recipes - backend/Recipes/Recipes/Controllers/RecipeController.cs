using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.DTOs;
using Recipes.DTOs.Delete;
using Recipes.DTOs.Get.Recipe;
using Recipes.DTOs.Post.Recipe;
using Recipes.Models;
using Recipes.Models.Users;
using Recipes.Services.Interface;

namespace Recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecipeController : ControllerBase
    {
        public readonly IRecipeService _recipes;

        public RecipeController(IRecipeService recipes)
        {
            _recipes = recipes;
        }

        /// <summary>
        /// Get all recipes
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-recipes")]
        [AllowAnonymous]

        public ActionResult<List<RecipeGetResponse>> getAllRecipes()
        {
            var response = _recipes.getAllRecipes();
            if(response == null)
            {
                return NotFound("No recipes found. ");
            }
            return Ok(response);
        }
        /// <summary>
        /// Get recipe by searching
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ingredientname"></param>
        /// <returns></returns>
        [HttpGet("get-searched-recipes")]
        [AllowAnonymous]

        public ActionResult<List<RecipesGetResponse>> getSearchedRecipes(string name,string ingredientname) {
            var response = _recipes.getSearchedRecipes(name,ingredientname);
            if (response == null)
            {
                return NotFound("No searched recipes found. ");
            }
            return Ok(response);
        }
        /// <summary>
        /// Create recipe (can be done only with cook)
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPost("create-recipe")]
        [Authorize(Roles = Roles.Cook)]

        public ActionResult<RecipePostResponse> createRecipe(RecipePostRequest recipe)
        {
            var response = _recipes.createRecipe(recipe,User.Identity.Name);
            if(recipe == null)
            {
                return BadRequest("Something went wrong, please try again. ");
            }
            return Ok(response);
        }
        /// <summary>
        /// Delete recipe (can be done only with cook) and Admin
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpDelete("delete-recipe")]
        [Authorize(Roles = Roles.Cook)]
        //[Authorize(Roles = Roles.Admin)]//mzd i ovako za admina
        public ActionResult<RecipeDeleteResponse> deleteRecipe(string name)
        {
            var response = _recipes.deleteRecipe(name, User.Identity.Name);
            if (response == null)
            {
                return BadRequest("Something went wrong, please try again. ");
            }
            return Ok(response);
        }
    }
}
