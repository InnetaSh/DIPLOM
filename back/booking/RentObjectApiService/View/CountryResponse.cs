using Globals.Controllers;
using Globals.Models;
using RentObjectApiService.Models;
using System.ComponentModel.DataAnnotations;

namespace RentObjectApiService.View
{
    public class CountryResponse : EntityBase, IBaseResponse
    {
        public string Title { get; set; }
        public List<City> Cities { get; set; }
    }

}
