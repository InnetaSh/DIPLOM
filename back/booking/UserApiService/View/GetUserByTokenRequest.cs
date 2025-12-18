using UserApiService.Models.Enums;

namespace UserApiService.View
{
    public class GetUserByTokenRequest
    {
        public string Token { get; set; } = null!;
        public UserRole Role { get; set; }
    }
}
