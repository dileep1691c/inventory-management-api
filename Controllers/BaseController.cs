using InventoryManagement.Models;
using InventoryManagement.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InventoryManagement.Controllers
{
    /// <summary>
    /// Base controller class that serves as a common base for other controllers in the application. It can be used to define shared functionality, properties, or methods that are applicable to multiple controllers.
    /// </summary>
    public class BaseController : Controller
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class with the specified user repository.
        /// </summary>
        /// <param name="userRepository"></param>
        public BaseController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// The user repository used for accessing user-related data.
        /// </summary>
        /// <returns></returns>
        protected async Task<User?> GetUserIdFromAccessToken()
        {
            var userEmail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userdetials = await _userRepository.GetUserByEmail(userEmail ?? string.Empty);
            return userdetials;
        }
    }
}
