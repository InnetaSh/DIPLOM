using Globals.Models;

namespace OfferApiService.Models.RentObjModel
{
    public class RentObjParamValue : EntityBase
    {
        public int RentObjId { get; set; }
        public RentObject RentObj { get; set; }

        public int ParamItemId { get; set; }
        public ParamItem ParamItem { get; set; }

        public bool? ValueBool { get; set; }
        public int? ValueInt { get; set; }
        public string ValueString { get; set; }
    }

}
