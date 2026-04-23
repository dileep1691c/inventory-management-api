using InventoryManagement.Helper;
using InventoryManagement.ModelDTO;
using InventoryManagement.Models;
using InventoryManagement.Services.IServices;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace InventoryManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly JWTSettings _jwtSettings;
        private readonly ILogger<AuthService> _logger;
        private readonly IConfiguration _configuration;
        
        public AuthService(IUserService userService, ILogger<AuthService> logger, IOptions<JWTSettings> jwtSettings, IConfiguration configuration) 
        {
            Console.WriteLine(jwtSettings.Value.ToString());
            _userService = userService;
            _logger = logger;
            _jwtSettings = jwtSettings.Value;
            _configuration = configuration;
        }

        public async Task<AuthResponse> AuthenticateUserAsync(LoginRequest loginRequest)
        {
            var user = await _userService.GetUserByEmail(loginRequest.Email);
            var authResponse = new AuthResponse();
            if (user == null)
            {
                _logger.LogInformation($"Authentication Failed for Email : {loginRequest.Email}");
                return null;
                
            }
            var storedPassword = user.Password;
            var passordBytes = Convert.FromBase64String(user.Salt);
            var hashedPassword = AuthHelper.HashPassword(loginRequest.Password, passordBytes);
            if (hashedPassword == storedPassword) 
            {
                authResponse.AccessToken = GenerateToken(user);
                authResponse.RefreshToken = GenerateRefreshToken();
                authResponse.ExpiresAt = DateTime.UtcNow;
                var User = new UserDTO
                {
                    FristName = user.FirstName,
                    LastName = user.LastName ?? "",
                    Email = user.Email,
                    RoleId = user.RoleId,
                };
                return authResponse;
            }
            return null;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
            throw new NotImplementedException();
        }

        public string GenerateToken(User user)
        {
            var PrimayKeyLocation = Path.GetFullPath(_configuration.GetSection("PrimayKeyLocation").Value);
            if(PrimayKeyLocation == null)
            {
                _logger.LogInformation("Not found Private Keys Location");
                return null;
            }
            var privateKey = File.ReadAllText(PrimayKeyLocation).ToString()??"";
            if(privateKey.Length == 0)
            {
                _logger.LogInformation("Private Key file is empty");
                return null;
            }
            _jwtSettings.SecretKey = privateKey;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.RoleId.ToString()),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationTime),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            _logger.LogInformation("Access token generated for user {Email}", user.Email);
            return tokenString;

            throw new NotImplementedException();
        }

        public Task ValidateRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task ValidateCredentialsAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}
