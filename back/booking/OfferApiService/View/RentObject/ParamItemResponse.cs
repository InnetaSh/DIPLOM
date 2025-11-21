

using Globals.Controllers;
using OfferApiService.Models.RentObject;
using OfferApiService.Models.RentObject.Enums;

namespace OfferApiService.View.RentObject
{
    public class ParamItemResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Title { get; set; }

        public ParamValueType ValueType { get; set; } = ParamValueType.Boolean;
    }
}
