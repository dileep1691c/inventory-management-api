using InventoryManagement.ModelDTO;
using InventoryManagement.Models;

namespace InventoryManagement.Services.IServices
{
    public interface IAuthService
    {
        Task<AuthResponse> AuthenticateUserAsync(LoginRequest loginRequest);

        string GenerateToken(User user);

        string GenerateRefreshToken();

        Task ValidateCredentialsAsync(string token);

        Task ValidateRefreshToken(string refreshToken);
    }
}
