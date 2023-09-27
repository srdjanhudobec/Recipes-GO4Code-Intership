using AutoMapper;
using Recipes.DTOs;
using Recipes.DTOs.Get.Recipe;
using Recipes.DTOs.Get.User;
using Recipes.DTOs.Post.User;
using Recipes.DTOs.UserBookmark;
using Recipes.Models;
using Recipes.Models.Users;
using Recipes.Repositorys.Interface;
using Recipes.Services.Interface;

namespace Recipes.Services.Service
{
    public class UserService:IUserService
    {
        public readonly IUserRepository _users;
        public readonly IMapper _mapper;

        public UserService(IUserRepository users, IMapper mapper)
        {
            _users = users;
            _mapper = mapper;
        }

        public UserBookMarkPostResponse bookmarkRecipe(UserBookmarkPostRequest bookmarkRecipe,string username)
        {
            var response = _mapper.Map<UserBookMarkPostResponse>(_users.bookmarkRecipe(_mapper.Map<UserBookmark>(bookmarkRecipe),username));
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public UserPostResponse createUser(UserPostRequest user)
        {
            var response = _mapper.Map<UserPostResponse>(_users.createUser(_mapper.Map<User>(user)));
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public List<UserGetResponse> getAllUsers()
        {
            var response = _mapper.Map<List<UserGetResponse>>(_users.getAllUsers());
            if (response == null)
            {
                return null;
            }
            return response;
        }

        public List<RecipesGetResponse> getBookmarkRecipes(string username)
        {
            var response = _mapper.Map<List<RecipesGetResponse>>(_users.getBookmarkedRecipes(username));
            if (response == null)
            {
                return null;
            }
            return response;
        }
    }
}
