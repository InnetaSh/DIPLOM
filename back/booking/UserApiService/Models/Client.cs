using System.Text.Json.Serialization;
using UserApiService.Models.Enums;

namespace UserApiService.Models
{
    public class Client : User
    {
        public UserRole RoleName { get; set; } = UserRole.Client;
 
        public int BonusCount { get; set; } = 0;

        public List<int> OrdersIdList { get; set; } = new List<int>();

    }
}
