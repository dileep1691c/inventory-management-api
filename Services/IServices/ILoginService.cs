using InventoryManagement.ModelDTO;

namespace InventoryManagement.Services.IServices
{
    /// <summary>
    /// Defines the contract for a login service that handles user authentication, password updates, and password recovery.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Authenticates a user based on the provided login request and returns an authentication response containing user details and tokens.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        Task<AuthResponse> LoginUser(LoginRequest loginRequest);
        
        /// <summary>
        /// Updates the password for the authenticated user.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        Task UpdatePassword(string password);
        
        /// <summary>
        /// Initiates the password recovery process for the specified user.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        Task ForgetPassword(string password);
    }
}
