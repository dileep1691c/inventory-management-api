using InventoryManagement.Models;
using InventoryManagement.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets all the users
        /// </summary>
        /// <returns></returns>
        [HttpGet("Users")]
        //[Route("/Users")]
        public async Task<ActionResult<IEnumerable<User?>>> Get()
        {
            return Ok(await _userService.GetAllAsync());  
        }
    }
}
