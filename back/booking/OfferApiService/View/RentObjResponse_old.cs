using Globals.Controllers;
using Globals.Models;
//using RentObjectApiService.Models;

namespace OfferApiService.View
{
    public class RentObjResponse_old : IBaseResponse
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        //public List<ParamsCategory> ParamCategories { get; set; }
        //public List<RentObjImage> Images { get; set; }
    }

}
