using Globals.Models;
using RentObjectApiService.Models;

namespace RentObjectApiService.View
{
    public class RentObjResponse : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        public List<ParamsCategory> ParamCategories { get; set; }
        public List<RentObjImage> Images { get; set; }
    }

}
