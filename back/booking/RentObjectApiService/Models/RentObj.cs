using Globals.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace RentObjectApiService.Models
{
    public class RentObj : EntityBase
    {
        public string Title { get; set; }

       
        public int CityId { get; set; }
        public City City { get; set; }

        public List<ParamsCategory> ParamCategories { get; set; }


    }

}
