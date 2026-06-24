using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.ModelDTO
{
    /// <summary>
    /// Response returned after a successful authentication containing user info and tokens.
    /// </summary>
    public class AuthResponse
    {
        /// <summary>
        /// The authenticated user's DTO.
        /// </summary>
        public UserDTO user { get; set; } = new();

        /// <summary>
        /// The issued access token (JWT) used for authenticating requests.
        /// </summary>
        public string AccessToken { get; set; } = string.Empty;

        /// <summary>
        /// The refresh token used to obtain a new access token when the access token expires.
        /// </summary>
        public string RefreshToken { get; set; } = string.Empty;

        /// <summary>
        /// The UTC date and time when the access token expires.
        /// </summary>
        public DateTime ExpiresAt { get; set; }
    }
}
