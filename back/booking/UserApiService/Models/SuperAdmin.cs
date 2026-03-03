using UserApiService.Models.Enums;

namespace UserApiService.Models
{
    public class SuperAdmin : User
    {
        public override UserRole RoleName { get; set; } = UserRole.SuperAdmin;

    }
}
