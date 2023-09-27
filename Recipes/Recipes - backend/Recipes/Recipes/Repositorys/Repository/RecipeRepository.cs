using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Recipes.Data;
using Recipes.DTOs;
using Recipes.Models;
using Recipes.Models.Ingredient;
using Recipes.Models.Users;
using Recipes.Repositorys.Interface;
using Recipes.Services.Service;
using System.Linq;

namespace Recipes.Repositorys.Repository
{
    public class RecipeRepository:IRecipeRepository
    {
        public readonly DatabaseContext _recipes;
        public RecipeRepository(DatabaseContext context)
        {
            _recipes = context;
        }

        public RecipeRepository() { }

        public Recipe createRecipe(Recipe recipe,string username)
        {
            recipe.CreatorUsername = username;
            recipe.Creator = _recipes.Users.FirstOrDefault(x => x.Username == username);
            foreach(var ingredient in recipe.Ingredients)
            {
                ingredient.IngredientId = _recipes.Ingredients.FirstOrDefault(x => x.Name == ingredient.IngredientName).Id;
            }
            if(recipe != null)
            {
                _recipes.Recipes.Add(recipe);
                _recipes.SaveChanges();
                return recipe;
            }
            return null;
        }

        public Recipe deleteRecipe(string name,string username)
        {
            if(name == null || username  == null)
            {
                return null;
            }
            Recipe r = _recipes.Recipes.FirstOrDefault(x => x.Name.ToLower() == name.ToLower() && x.CreatorUsername == username);
            if(r != null)
            {
                _recipes.Recipes.Remove(r);
                _recipes.SaveChanges();
                return r;
            }
            return null;
        }

        public List<Recipe> getAllRecipes()
        {
            return _recipes.Recipes
        .Include(r => r.Ingredients)
            .ThenInclude(ri => ri.Ingredient)
        .ToList();

        }

        public List<Recipe> getSearchedRecipes(string name, string ingredientname)
        {
            if(name == "" && ingredientname == "")
            {
                return getAllRecipes();
            }
            List<Recipe> recipes = getAllRecipes();
            List<Recipe> searched = new List<Recipe>();

            foreach (var recipe in recipes)
            {
                if (recipe.Name.ToLower().Contains(name.ToLower()))
                {
                    foreach (var ing in recipe.Ingredients)
                    {
                        if (ing.IngredientName.ToLower().Contains(ingredientname.ToLower()))
                        {
                            searched.Add(recipe);
                        }
                    }
                }
            }
            if (searched.Count > 0)
            {
                return searched;
            }
            return null;
        }
    }
}
