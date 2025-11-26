using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfferApiService.Models.RentObject;
using OfferApiService.Services.Interfaces.RentObject;
using OfferApiService.View.RentObject;


namespace OfferApiService.Controllers.RentObject
{

    
    public class CityController : EntityControllerBase<City, CityResponse, CityRequest>
    {
        public CityController(ICityService cityService, IRabbitMqService mqService)
            : base(cityService, mqService)
                {
                }



        protected override City MapToModel(CityRequest request)
        {
            return new City
            {
                id = request.id,
                Title = request.Title,
                CountryId = request.CountryId
            };
        }

        protected override CityResponse MapToResponse(City model)
        {
            return new CityResponse
            {
                id = model.id,
                Title = model.Title,
                CountryId = model.CountryId
            };
        }
    }
}