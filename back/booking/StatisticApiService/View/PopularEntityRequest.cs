using Globals.Controllers;

namespace StatisticApiService.View
{
    public class PopularEntityRequest : IBaseRequest
    {
        public int EntityId { get; set; }
        public int Score { get; set; }
    }
}
