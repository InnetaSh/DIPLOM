using Globals.Models;
using System.ComponentModel.DataAnnotations;

namespace OfferApiService.Models.RentObject
{
    public class City : EntityBase
    {
        public string Title { get; set; }

        public int CountryId { get; set; }
        public string Country { get; set; }

    }

}
