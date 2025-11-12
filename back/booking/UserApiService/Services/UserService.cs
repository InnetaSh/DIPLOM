using Globals.Sevices;
using UserApiService.Models;
using UserApiService.Services.Interfaces;

namespace UserApiService.Services
{
    public class UserService: ServiceBase<User, UserContext>, IUserService
    {

    }
}
