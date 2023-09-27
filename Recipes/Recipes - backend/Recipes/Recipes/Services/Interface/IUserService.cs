using Recipes.DTOs;
using Recipes.DTOs.Get.Recipe;
using Recipes.DTOs.Get.User;
using Recipes.DTOs.Post.User;
using Recipes.DTOs.UserBookmark;
using Recipes.Models;

namespace Recipes.Services.Interface
{
    public interface IUserService
    {
        public UserPostResponse createUser(UserPostRequest user);

        public List<UserGetResponse> getAllUsers();

        public UserBookMarkPostResponse bookmarkRecipe(UserBookmarkPostRequest bookmarkRecipe,string username);

        public List<RecipesGetResponse> getBookmarkRecipes(string username);
    }
}
