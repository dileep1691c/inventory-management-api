namespace InventoryManagement.Models
{
    public class JWTSettings
    {
        public string Issuer { get; set; } = string.Empty;

        public string SecretKey { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public int AccessTokenExpirationTime { get; set; }

        public int RefreshTokenExpirationTime { get; set; }
    }
}
