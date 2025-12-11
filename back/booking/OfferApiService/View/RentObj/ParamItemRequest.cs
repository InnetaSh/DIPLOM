using Globals.Controllers;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Models.RentObjModel.Enums;

namespace OfferApiService.View.RentObj
{
    public class ParamItemRequest : IBaseRequest
    {
        public int id { get; set; }

        public int CategoryId { get; set; }
        public ParamValueType ValueType { get; set; } = ParamValueType.Boolean;

        public bool? ValueBool { get; set; }
        public int? ValueInt { get; set; }
        public string ValueString { get; set; }

        public static ParamItem MapToModel(ParamItemRequest request)
        {
            return new ParamItem
            {
                id = request.id,
                CategoryId = request.CategoryId,
                ValueType = request.ValueType
            };
        }
    }
}
