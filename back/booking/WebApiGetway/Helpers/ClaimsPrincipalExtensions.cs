using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace WebApiGetway.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
       public static int GetUserId(this ClaimsPrincipal user)
        {
            if (user == null) return -1;

           
            var claim = user.FindFirst(ClaimTypes.NameIdentifier)
                        ?? user.FindFirst(JwtRegisteredClaimNames.Sub);

            return int.TryParse(claim?.Value, out var id) ? id : -1;
        }
    }
}
