using InventoryManagement.ModelDTO;
using InventoryManagement.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.AuthenticationController
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequest request) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Login API Hit");
            var loginDetails = await _authService.AuthenticateUserAsync(request);
            if (loginDetails == null) 
            {
                return Unauthorized(new { message = "Invalid Email or Password"});
            }
            return Ok(loginDetails);
        }
    }
}
