using Globals.Controllers;

namespace OfferContracts.RentObj
{
    public class ParamsCategoryResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public bool IsFilterable { get; set; }
        public List<ParamItemResponse> Items { get; set; } = new();
    }
}
