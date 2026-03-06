using Globals.Controllers;

namespace OfferContracts.RentObj
{
    public class RentObjParamValueRequest : IBaseRequest
    {
        public int id { get; set; }

        public int RentObjId { get; set; }
        public int ParamItemId { get; set; }

        public bool? ValueBool { get; set; }
        public int? ValueInt { get; set; }
        public string? ValueString { get; set; }
        public string? IconName { get; set; } = null;

    }
}
