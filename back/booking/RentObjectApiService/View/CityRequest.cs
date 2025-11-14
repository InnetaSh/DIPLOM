using Globals.Models;
using RentObjectApiService.Models;
using System.ComponentModel.DataAnnotations;

namespace RentObjectApiService.View
{
    public class CityRequest : EntityBase
    {
        public string Title { get; set; }

        public int CountryId { get; set; }
        public string Country { get; set; }

        public List<RentObj> RentObjs { get; set; }
    }


}
