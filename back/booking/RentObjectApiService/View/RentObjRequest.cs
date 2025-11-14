using Globals.Models;
using RentObjectApiService.Models;

namespace RentObjectApiService.View
{
    public class RentObjRequest : EntityBase
    {                 
        public string Title { get; set; }             
        public int CityId { get; set; }              
        public City City { get; set; }        
        public List<ParamsCategoryRequest> ParamCategories { get; set; }
    }
}
