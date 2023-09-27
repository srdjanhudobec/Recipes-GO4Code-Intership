using Microsoft.AspNetCore.Identity;
using Recipes.Data;
using Recipes.Models;
using Recipes.Models.Ingredient;
using Recipes.Repositorys.Interface;
using Recipes.Repositorys.Interface;

namespace Recipes.Repositorys.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        public readonly DatabaseContext _ingredients;
        public IngredientRepository(DatabaseContext context)
        {
            _ingredients = context;
        }

        public IngredientRepository() { }

        public Ingredient createIngredient(Ingredient ingredient)
        {
            if(ingredient.MeasurementUnit.Equals("ml") == false && ingredient.MeasurementUnit.Equals("g") == false && ingredient.MeasurementUnit.Equals("kom") == false)
            {
                return null;
            }
            if(ingredient != null ) {
                _ingredients.Ingredients.Add(ingredient);
                _ingredients.SaveChanges();
                return ingredient;
            }
            return null;
        }

        public Ingredient deleteIngredient(string name)
        {
            if(name != null)
            {
                Ingredient i = _ingredients.Ingredients.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
                if(i != null)
                {
                    _ingredients.Ingredients.Remove(i);
                    _ingredients.SaveChanges();
                    return i;
                }
                return null;
            }
            return null;
        }

        public List<Ingredient> getAllIngredients()
        {
            return _ingredients.Ingredients.ToList();
        }

    }
}
