using System.Text.Json.Serialization;
using UserContracts.Enums;

namespace UserApiService.Models
{
    public class Client : User
    {
        public int BonusCount { get; set; } = 0;
        public override UserRole RoleName { get; set; } = UserRole.Client;
        public List<ClientOrderLink> ClientOrderLinks { get; set; } = new();

        public List<HistoryOfferLink> HistoryOfferLinks { get; set; } = new();
    }
}
