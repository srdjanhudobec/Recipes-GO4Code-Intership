using Microsoft.AspNetCore.Identity;
using Recipes.Data;
using Recipes.Models;
using Recipes.Models.Users;
using Recipes.Repositorys.Interface;

namespace Recipes.Repositorys.Repository
{
    public class UserRepository:IUserRepository
    {
        public readonly DatabaseContext _users;
        public readonly IRecipeRepository _recipes;
        public UserRepository(DatabaseContext context,IRecipeRepository recipes)
        {
            _users = context;
            _recipes = recipes;
        }

        public UserRepository() { }

        public User createUser(User user)
        {
            if (user != null)
            {
                _users.Add(user);
                _users.SaveChanges();
                return user;
            }
            return null;
        }

        public List<User> getAllUsers()
        {
            return _users.Users.ToList();
        }

        public UserBookmark bookmarkRecipe(UserBookmark bookmark, string username)
        {
            bookmark.UserUsername = username;
            if (bookmark != null)
            {
                int recipeId = _users.Recipes.FirstOrDefault(x => x.Name == bookmark.RecipeName).Id;
                int userId = _users.Users.FirstOrDefault(x => x.Username == bookmark.UserUsername).Id;

                if(recipeId != 0 && userId != 0)
                {
                    bookmark.RecipeId = recipeId;
                    bookmark.UserId = userId;
                }
                foreach(var b in _users.Bookmarks)
                {
                    if(b.RecipeName == bookmark.RecipeName && userId == b.UserId)
                    {
                        return null;
                    }
                }
                _users.Bookmarks.Add(bookmark);
                _users.SaveChanges();
                return bookmark;
            }
            return null;
        }

        public List<Recipe> getBookmarkedRecipes(string username)
        {
            List<Recipe> recipes = new List<Recipe>();
            List<UserBookmark> bookmarks = _users.Bookmarks.ToList();
            foreach(var bookmarked in bookmarks)
            {
                if (bookmarked.UserUsername == username)
                {
                    Recipe r = _recipes.getAllRecipes().FirstOrDefault(x => x.Name == bookmarked.RecipeName);
                    if(r!=null)
                    {
                        recipes.Add(r);
                    }
                }
            }
            if(recipes.Count > 0)
            {
                return recipes;
            }
            return null;
        }
    }
}
