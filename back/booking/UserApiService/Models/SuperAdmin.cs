using UserApiService.Models.Enums;

namespace UserApiService.Models
{
    public class SuperAdmin : User
    {
        public new UserRole RoleName { get; set; } = UserRole.SuperAdmin;

    }
}
