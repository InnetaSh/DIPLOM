using System.Text.Json.Serialization;
using UserApiService.Models.Enums;

namespace UserApiService.Models
{
    public class Client : User
    {
        public int BonusCount { get; set; } = 0;
        public List<ClientOrderLink> ClientOrderLinks { get; set; } = new();

        public List<HistoryOfferLink> HistoryOfferLinks { get; set; } = new();
    }
}
