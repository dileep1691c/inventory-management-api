using InventoryManagement.Models;
using InventoryManagement.Repository.IRepository;
using InventoryManagement.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    /// <summary>
    /// Controller responsible for handling user-related operations. It provides endpoints for retrieving user information and managing user data.
    /// </summary>
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class with the specified user service and user repository.
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="userRepository"></param>
        public UserController(IUserService userService, IUserRepository userRepository) : base(userRepository) 
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns></returns>
        [HttpGet("Users")]
        public async Task<ActionResult<IEnumerable<User?>>> Get()
        {
            var user = await GetUserIdFromAccessToken();
            if (user != null)
            {
                return Ok(await _userService.GetAllAsync());
            }
            return Unauthorized();
        }
    }
}
