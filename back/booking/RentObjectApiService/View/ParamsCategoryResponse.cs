using Globals.Controllers;
using Globals.Models;

namespace RentObjectApiService.View
{
    public class ParamsCategoryResponse : EntityBase, IBaseResponse
    {
        public string Title { get; set; }
        public List<RentObjParamRequest> Params { get; set; }
    }
}
