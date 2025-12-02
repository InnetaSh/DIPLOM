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
                   CountryId = request.CountryId,
                   Latitude = request.Latitude,
                   Longitude = request.Longitude,
                   Attractions = request.Attractions?.Select(a => new Attraction
                   {
                       id = a.id,
                       Name = a.Name,
                       Description = a.Description,
                       Latitude = a.Latitude,
                       Longitude = a.Longitude
                   }).ToList()
               };
        
        }

        protected override CityResponse MapToResponse(City model)
        {
            return new CityResponse
            {
                id = model.id,
                Title = model.Title,
                CountryId = model.CountryId,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Attractions = model.Attractions?.Select(a => new AttractionResponse
                  {
                      id = a.id,
                      Name = a.Name,
                      Description = a.Description,
                      Latitude = a.Latitude,
                      Longitude = a.Longitude
                  }).ToList()
            };
        }
    }
}