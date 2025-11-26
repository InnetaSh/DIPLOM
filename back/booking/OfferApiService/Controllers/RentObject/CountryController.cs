using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObject;
using OfferApiService.Services.Interfaces.RentObject;
using OfferApiService.View.RentObject;

namespace OfferApiService.Controllers.RentObject
{
    public class CountryController : EntityControllerBase<Country, CountryResponse, CountryRequest>
    {
        public CountryController(ICountryService countryService, IRabbitMqService mqService)
            : base(countryService, mqService)
        {
        }


        protected override Country MapToModel(CountryRequest request)
        {
            return new Country
            {
                id = request.id,
                Title = request.Title,
                Cities = request.Cities?.Select(c => new City
                {
                    id = c.id,
                    Title = c.Title,
                    CountryId = request.id
                }).ToList() ?? new List<City>()
            };
        }

        protected override CountryResponse MapToResponse(Country model)
        {
            return new CountryResponse
            {
                id = model.id,
                Title = model.Title,
                Cities = model.Cities?.Select(c => new CityResponse
                {
                    id = c.id,
                    Title = c.Title,
                    CountryId = model.id,
                    Country = model.Title  
                }).ToList() ?? new List<CityResponse>()
            };
        }
    }
}