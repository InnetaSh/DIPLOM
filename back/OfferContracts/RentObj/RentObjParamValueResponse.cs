using Globals.Controllers;

namespace OfferContracts.RentObj
{
    public class RentObjParamValueResponse : IBaseResponse
    {
        public int id { get; set; }
        public int RentObjId { get; set; }
        public int ParamItemId { get; set; }
        public string? IconName { get; set; } = null;

        public string Title { get; set; }  
        public bool? ValueBool { get; set; }
        public int? ValueInt { get; set; }
        public string ValueString { get; set; }

    }
}
