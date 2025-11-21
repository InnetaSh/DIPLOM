

using Globals.Controllers;
using OfferApiService.Models.RentObject;
using OfferApiService.Models.RentObject.Enums;

namespace OfferApiService.View.RentObject
{
    public class ParamItemRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public ParamValueType ValueType { get; set; } = ParamValueType.Boolean;

        public bool? ValueBool { get; set; }
        public int? ValueInt { get; set; }
        public string ValueString { get; set; }

    }
}
