using Globals.Controllers;

namespace StatisticApiService.View
{
    public class PopularEntityResponse : IBaseResponse
    {
        public int EntityId { get; set; }
        public string? Title { get; set; }
        public int Score { get; set; }
    }
}
