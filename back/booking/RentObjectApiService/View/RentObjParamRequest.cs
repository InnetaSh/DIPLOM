using Globals.Controllers;
using Globals.Models;
using RentObjectApiService.Models.Enums;

namespace RentObjectApiService.View
{
    public class RentObjParamRequest : IBaseRequest
    {
        public string Title { get; set; }
        public ParamType Type { get; set; }
        public object Value { get; set; }
    }
}
