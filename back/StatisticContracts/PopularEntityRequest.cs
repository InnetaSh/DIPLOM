using Globals.Controllers;

namespace StatisticContracts
{
    public class PopularEntityRequest : IBaseRequest
    {
        public int EntityId { get; set; }
        public int Score { get; set; }
    }
}
