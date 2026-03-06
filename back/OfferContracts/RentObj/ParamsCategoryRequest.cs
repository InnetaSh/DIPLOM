using Globals.Controllers;

namespace OfferContracts.RentObj
{
    public class ParamsCategoryRequest : IBaseRequest
    {
        public int id { get; set; }
        public List<ParamItemRequest> Items { get; set; } = new();
        public bool IsFilterable { get; set; }
    }
}
