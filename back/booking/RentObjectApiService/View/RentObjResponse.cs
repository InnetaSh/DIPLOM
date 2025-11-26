using Globals.Controllers;
using Globals.Models;
using RentObjectApiService.Models;

namespace RentObjectApiService.View
{
    public class RentObjResponse: IBaseResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public List<ParamsCategory> ParamCategories { get; set; }
        public List<string> Images { get; set; }
    }

}
