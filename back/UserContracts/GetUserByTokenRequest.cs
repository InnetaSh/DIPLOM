
using UserContracts.Enums;

namespace UserContracts
{
    public class GetUserByTokenRequest
    {
        public string Token { get; set; } = null!;
        public UserRole Role { get; set; }
    }
}
