

using Globals.Controllers;
using OfferApiService.Models.RentObject;
using OfferApiService.Services.Interfaces.RentObject;

namespace OfferApiService.View.RentObject
{
    public class RentObjParamValueResponse : IBaseResponse
    {
        public int id { get; set; }
        public int RentObjId { get; set; }
        public int ParamItemId { get; set; }

        public string ParamItemTitle { get; set; }  
        public bool? ValueBool { get; set; }
        public int? ValueInt { get; set; }
        public string ValueString { get; set; }



        public static RentObjParamValueResponse MapToResponse(RentObjParamValue model, IRentObjParamValueService service)
        {
            string title = service.GetTitleParamItem(model.ParamItemId).Result;
            return new RentObjParamValueResponse
            {
                id = model.id,
                RentObjId = model.RentObjId,
                ParamItemId = model.ParamItemId,
                ParamItemTitle = title,
                ValueBool = model.ValueBool,
                ValueInt = model.ValueInt,
                ValueString = model.ValueString
            };

        }
    }


}
