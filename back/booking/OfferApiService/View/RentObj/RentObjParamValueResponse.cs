

using Globals.Controllers;
using OfferApiService.Models.RentObjModel;

namespace OfferApiService.View.RentObj
{
    public class RentObjParamValueResponse : IBaseResponse
    {
        public int id { get; set; }
        public int RentObjId { get; set; }
        public int ParamItemId { get; set; }

        public string Title { get; set; }  
        public bool? ValueBool { get; set; }
        public int? ValueInt { get; set; }
        public string ValueString { get; set; }



        public static RentObjParamValueResponse MapToResponse(RentObjParamValue model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return new RentObjParamValueResponse
            {
                id = model.id,
                RentObjId = model.RentObjId,
                ParamItemId = model.ParamItemId,
                ValueBool = model.ValueBool,
                ValueInt = model.ValueInt,
                ValueString = model.ValueString
            };

        }
    }


}
