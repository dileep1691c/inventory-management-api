using InventoryManagement.ModelDTO;
using InventoryManagement.Models;

namespace InventoryManagement.Services.IServices
{
    public interface IAuthService
    {
        /// <summary>
        /// Authenticates a user based on the provided login request and returns an authentication response containing user details, access token, refresh token, and expiration time.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuthResponse> AuthenticateUserAsync(LoginRequest loginRequest);

        /// <summary>
        /// Generates a JWT token for the specified user, which can be used for authentication and authorization purposes.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string GenerateToken(User user);

        /// <summary>
        /// Generates a secure random refresh token that can be used to obtain a new access token when the current one expires.
        /// </summary>
        /// <returns></returns>
        string GenerateRefreshToken();

        /// <summary>
        /// Validates the provided JWT token to ensure it is valid, not expired, and has not been tampered with. Throws an exception if the token is invalid.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task ValidateCredentialsAsync(string token);

        /// <summary>
        /// Validates the provided refresh token to ensure it is valid and has not been tampered with. Throws an exception if the refresh token is invalid.
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task ValidateRefreshToken(string refreshToken);
    }
}
