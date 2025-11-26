using Globals.Controllers;
using Globals.Models;
using RentObjectApiService.Models;

namespace RentObjectApiService.View
{
    public class RentObjRequest : EntityBase, IBaseRequest
    {                 
        public string Title { get; set; }             
        public int CityId { get; set; }              
        public City City { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<ParamsCategoryRequest> ParamCategories { get; set; }
    }
}
