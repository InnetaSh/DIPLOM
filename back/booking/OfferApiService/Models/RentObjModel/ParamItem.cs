using Globals.Models;
using OfferApiService.Models.RentObjModel.Enums;


namespace OfferApiService.Models.RentObjModel
{
    public class ParamItem  : EntityBase
    {

        public int CategoryId { get; set; }
        public ParamsCategory Category { get; set; }

        public bool IsFilterable { get; set; } = true;  // Можно ли использовать этот параметр в фильтрах поиска

        public ParamValueType ValueType { get; set; } = ParamValueType.Boolean;

     
    }
}


