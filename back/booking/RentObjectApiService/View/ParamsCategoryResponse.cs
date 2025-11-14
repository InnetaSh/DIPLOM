using Globals.Models;

namespace RentObjectApiService.View
{
    public class ParamsCategoryResponse : EntityBase
    {
        public string Title { get; set; }
        public List<RentObjParamRequest> Params { get; set; }
    }
}
