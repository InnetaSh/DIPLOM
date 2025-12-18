using UserApiService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserApiService.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
    }

    public class TokenService : ITokenService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Secret Key is not configured.");
            _issuer = configuration["Jwt:Issuer"] ?? "beauti_salon_app";
            _audience = configuration["Jwt:Audience"] ?? "beauti_salon_users";
        }

        public string GenerateJwtToken(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()), 
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("name", user.Username),
                new Claim(ClaimTypes.Role, user.RoleName.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
