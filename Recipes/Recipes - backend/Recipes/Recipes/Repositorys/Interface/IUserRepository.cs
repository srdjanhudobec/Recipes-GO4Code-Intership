using Recipes.Models;
using Recipes.Models.Users;

namespace Recipes.Repositorys.Interface
{
    public interface IUserRepository
    {
        public User createUser(User user);
    
        public List<User> getAllUsers();

        public UserBookmark bookmarkRecipe(UserBookmark bookmark,string username);

        public List<Recipe> getBookmarkedRecipes(string username);

    }
}
