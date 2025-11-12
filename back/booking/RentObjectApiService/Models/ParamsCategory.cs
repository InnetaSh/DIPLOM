using Globals.Models;

namespace RentObjectApiService.Models
{
    public class ParamsCategory : EntityBase
    {
        public string Title { get; set; }
        public List<RentObjParam> Params { get; set; }
    }
}
