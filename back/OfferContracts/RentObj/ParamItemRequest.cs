using Globals.Controllers;
using OfferContracts.RentObj.Enums;

namespace OfferContracts.RentObj
{
    public class ParamItemRequest : IBaseRequest
    {
        public int id { get; set; }

        public int CategoryId { get; set; }
        public ParamValueType ValueType { get; set; } = ParamValueType.Boolean;
        public bool IsFilterable { get; set; }
        public string? IconName { get; set; } = null;
        public bool? ValueBool { get; set; }
        public int? ValueInt { get; set; }
        public string ValueString { get; set; }
    }
}
