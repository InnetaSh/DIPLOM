using Globals.Models;
using UserApiService.Models;

namespace UserApiService.View
{
    public class UserRequest : User
    {
        public string Password { get; set; }
    }
}
