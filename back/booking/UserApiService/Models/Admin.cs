using UserApiService.Models.Enums;

namespace UserApiService.Models
{
    public class Admin : User
    {
        public new UserRole RoleName { get; set; } = UserRole.Admin;
        public string WorkRegion { get; set; }

    }
}
