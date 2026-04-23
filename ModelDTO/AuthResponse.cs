using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.ModelDTO
{
    public class AuthResponse
    {
        public UserDTO user { get; set; } = new();

        public string AccessToken { get; set; } = string.Empty;

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime ExpiresAt { get; set; }
    }
}
