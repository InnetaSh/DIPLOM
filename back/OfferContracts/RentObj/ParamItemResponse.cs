using Globals.Controllers;
using OfferContracts.RentObj.Enums;

namespace OfferContracts.RentObj
{
    public class ParamItemResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public int CategoryId { get; set; }
        public bool IsFilterable { get; set; }
        public string? IconName { get; set; } = null;
        public ParamValueType ValueType { get; set; } = ParamValueType.Boolean;

    }
}
