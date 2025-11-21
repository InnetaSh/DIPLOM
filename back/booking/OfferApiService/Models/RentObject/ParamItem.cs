using Globals.Models;
using OfferApiService.Models.RentObject.Enums;
namespace OfferApiService.Models.RentObject
{
    public class ParamItem : EntityBase
    {
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public ParamsCategory Category { get; set; }

        public ParamValueType ValueType { get; set; } = ParamValueType.Boolean;

        public List<RentObjParamValue> RentObjValues { get; set; } = new();
    }
}


