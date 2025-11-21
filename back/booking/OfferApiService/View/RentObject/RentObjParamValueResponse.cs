

using Globals.Controllers;
using OfferApiService.Models.RentObject;

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
    }
}
