using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recipes.DTOs.Post.User;
using Recipes.Models.Users;
using Recipes.Models;
using Recipes.Services.Interface;
using Recipes.DTOs.Get.User;
using Recipes.DTOs.UserBookmark;
using Recipes.DTOs.Get.Recipe;
using Azure.Core;

namespace Recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IUserService _users;

        public UserController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserService users,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _users = users;
            _mapper = mapper;
        }

        /// <summary>
        /// Register cook (can be done only by admin)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [Route("register-cook")]
        public async Task<IActionResult> RegisterCook([FromBody] UserPostRequest model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            User u = _mapper.Map<User>(_users.createUser(model));
            var createdUser = _users.getAllUsers().FirstOrDefault(x => x.Username == model.Username);
            u.Id = _mapper.Map<User>(createdUser).Id;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest("You must enter one UpperCase char,one number and one special character.");

            if (!await _roleManager.RoleExistsAsync(Roles.Cook))
                await _roleManager.CreateAsync(new IdentityRole(Roles.Cook));


            if (await _roleManager.RoleExistsAsync(Roles.Cook))
                await _userManager.AddToRoleAsync(user, Roles.Cook);



            if (u != null)
            {
                return Ok(u);
            }
            else
            {
                return BadRequest("Failed Creation.");
            }
        }
        /// <summary>
        /// Get all cooks (can be done only by admin)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        [Route("get-all-cooks")]
        public async Task<ActionResult<List<UserGetResponse>>> getAllCooks()
        {
            List<UserGetResponse> allUsers = _users.getAllUsers().ToList();
            List<UserGetResponse> cooks = new List<UserGetResponse>();
            for (int i=0;i<allUsers.Count;i++)
            {
                var user = await _userManager.FindByNameAsync(allUsers[i].Username);
                var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
                if (roles.Contains("Cook"))
                {
                    cooks.Add(allUsers[i]);
                }
            }
            if(cooks.Count > 0)
            {
                return cooks;
            }
            else
            {
                return NotFound("No cooks found!");
            }
          
        }

        /// <summary>
        /// Register admin (ovo predstavlja simulaciju za rucno unosenje admina u bazu,radi se preko kontrolera iskljucivo jer mora sam Identity da generise podatke i rolu admina, nigde se na frontu ovo nece pozivati)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserPostRequest model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            User u = _mapper.Map<User>(_users.createUser(model));
            var createdUser = _users.getAllUsers().FirstOrDefault(x => x.Username == model.Username);
            u.Id = _mapper.Map<User>(createdUser).Id;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest("You must enter one UpperCase char,one number and one special character.");

            if (!await _roleManager.RoleExistsAsync(Roles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));

            if (await _roleManager.RoleExistsAsync(Roles.Admin))
                await _userManager.AddToRoleAsync(user, Roles.Admin);


            if (u != null)
            {
                return Ok(u);
            }
            else
            {
                return BadRequest("Failed Creation.");
            }
        }
        /// <summary>
        /// Bookmark recipe (can be done only by user)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("bookmark-recipe")]
        [Authorize(Roles = Roles.User)]

        public ActionResult<UserBookMarkPostResponse> bookmarkRecipe(UserBookmarkPostRequest request)
        {
            try
            {
                var response = _users.bookmarkRecipe(request,User.Identity.Name);
                if (response == null)
                {
                    return BadRequest("Cant bookmark this recipe.");
                }
                return Ok(response);
            }
            catch
            {
                return BadRequest("Something went wrong, please try again. ");
            }
        }
        /// <summary>
        /// Get bookmarked recipes (can be done only by user)
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-bookmarked-recipes")]
        [Authorize(Roles = Roles.User)]

        public ActionResult<List<RecipeGetResponse>> getBookmarkedRecipes()
        {
            var response = _users.getBookmarkRecipes(User.Identity.Name);
            if (response == null)
            {
                return NotFound("No bookmarked recipes found. ");
            }
            return Ok(response);
        }
    }
}
