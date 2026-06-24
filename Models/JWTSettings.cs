namespace InventoryManagement.Models
{
    /// <summary>
    /// Represents the settings for JSON Web Token (JWT) authentication, including issuer, secret key, audience, and token expiration times.
    /// </summary>
    public class JWTSettings
    {
        /// <summary>
        /// Gets or sets the issuer of the JWT, which identifies the principal that issued the token.
        /// </summary>
        public string Issuer { get; set; } = string.Empty;

        public string SecretKey { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the audience for the JWT, which identifies the recipients that the token is intended for.
        /// </summary>
        public string Audience { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the expiration time for the access token in minutes, indicating how long the token is valid before it expires.
        /// </summary>
        public int AccessTokenExpirationTime { get; set; }

        /// <summary>
        /// Gets or sets the expiration time for the refresh token in minutes, indicating how long the refresh token is valid before it expires.
        /// </summary>
        public int RefreshTokenExpirationTime { get; set; }
    }
}
