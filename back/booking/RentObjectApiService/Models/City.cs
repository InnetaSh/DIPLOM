using Globals.Models;
using System.ComponentModel.DataAnnotations;

namespace RentObjectApiService.Models
{
    public class City : EntityBase
    {
        public string Title { get; set; }

        public int CountryId { get; set; }
        public string Country { get; set; }

        public List<RentObj> RentObjs { get; set; }
    }

}
