using InventoryManagement.Models;
using InventoryManagement.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpGet("Users")]
        //[Route("/Users")]
        public async Task<ActionResult<IEnumerable<User?>>> Get()
        {
            return Ok(await _userService.GetAllAsync());  
        }
    }
}
