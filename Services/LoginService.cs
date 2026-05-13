using InventoryManagement.ModelDTO;
using InventoryManagement.Services.IServices;

namespace InventoryManagement.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAuthService _authService;
        public LoginService(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<AuthResponse> LoginUser(LoginRequest loginRequest)
        {
            return await _authService.AuthenticateUserAsync(loginRequest);
        }

        public Task ForgetPassword(string password)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePassword(string password)
        {
            throw new NotImplementedException();
        }
    }
}
