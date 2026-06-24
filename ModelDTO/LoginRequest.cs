namespace InventoryManagement.ModelDTO
{
    /// <summary>
    /// Request model for user login containing credentials.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// The user's email address used to login.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The user's password used to login.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
