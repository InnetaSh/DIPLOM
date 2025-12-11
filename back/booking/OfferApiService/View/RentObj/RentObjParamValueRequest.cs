using Globals.Controllers;
using OfferApiService.Models.RentObjModel;

namespace OfferApiService.View.RentObj
{
    public class RentObjParamValueRequest : IBaseRequest
    {
        public int id { get; set; }

        public int RentObjId { get; set; }
        public int ParamItemId { get; set; }

        public bool ValueBool { get; set; }
        public int ValueInt { get; set; }
        public string ValueString { get; set; }

        public static RentObjParamValue MapToModel(RentObjParamValueRequest request)
        {
            return new RentObjParamValue
            {
                id = request.id,
                RentObjId = request.RentObjId,
                ParamItemId = request.ParamItemId,
                ValueBool = request.ValueBool,
                ValueInt = request.ValueInt,
                ValueString = request.ValueString
            };
        }
    }
}
