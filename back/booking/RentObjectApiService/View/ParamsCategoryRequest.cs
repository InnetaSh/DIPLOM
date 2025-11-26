using Globals.Controllers;

namespace RentObjectApiService.View
{
    public class ParamsCategoryRequest: IBaseRequest
    {
        public int id { get; set; }
        public string Title { get; set; }
        public List<RentObjParamRequest> Params { get; set; }
    }
}
