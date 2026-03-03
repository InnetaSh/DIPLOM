using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using TranslationApiService.Models.Location;
using TranslationApiService.Service.Location.Interface;
using TranslationApiService.View;


namespace TranslationApiService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CityController : TranslationEntityControllerBase<CityTranslation, TranslationResponse, TranslationRequest>
    {
        public CityController(ICityService cityService, IRabbitMqService mqService)
            : base(cityService, mqService)
                {
                }



        protected override CityTranslation MapToModel(TranslationRequest request)
        {
            return new CityTranslation
            {
               
                   id = request.id,
                   Title = request.Title,
                   Description=request.Description,
                   History=request.History,
                   Slug = request.Slug,
                   Lang = request.Lang
            };
        
        }

        protected override TranslationResponse MapToResponse(CityTranslation model)
        {
            return new TranslationResponse
            {
                id = model.id,
                Title = model.Title,
                Description=model.Description,
                History=model.History,
                EntityId = model.EntityId,
                Slug = model.Slug,
                Lang = model.Lang
              
            };
        }
    }
}