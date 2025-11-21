
using Globals.Controllers;

namespace OfferApiService.View.RentObject
{
    public class RentObjParamValueRequest : IBaseRequest
    {
        public int id { get; set; }

        public int RentObjId { get; set; }      
        public int ParamItemId { get; set; }    

        public bool ValueBool { get; set; }
        public int ValueInt { get; set; }
        public string ValueString { get; set; }
    }
}
