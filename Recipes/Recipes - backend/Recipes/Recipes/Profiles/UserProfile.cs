using AutoMapper;
using Recipes.DTOs.Get.User;
using Recipes.DTOs.Post.User;
using Recipes.DTOs.UserBookmark;
using Recipes.Models;
using Recipes.Models.Users;

namespace Recipes.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserPostRequest>();
            CreateMap<UserPostRequest, User>();
            CreateMap<User, UserPostResponse>();
            CreateMap<UserPostResponse,User>();
            CreateMap<User, UserGetResponse>();
            CreateMap<UserGetResponse, User>();
            CreateMap<UserBookmark, UserBookmarkPostRequest>();
            CreateMap<UserBookmarkPostRequest, UserBookmark>();
            CreateMap<UserBookmark, UserBookMarkPostResponse>();
            CreateMap<UserBookMarkPostResponse, UserBookmark>();
        }
    }
}
