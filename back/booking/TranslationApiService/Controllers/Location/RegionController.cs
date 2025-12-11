using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using TranslationApiService.Models.Location;
using TranslationApiService.Service.Location.Interface;
using TranslationApiService.View;


namespace TranslationApiService.Controllers
{

    
    public class RegionController : TranslationEntityControllerBase<RegionTranslation, TranslationResponse, TranslationRequest>
    {
        public RegionController(IRegionService regionService, IRabbitMqService mqService)
            : base(regionService, mqService)
                {
                }



        protected override RegionTranslation MapToModel(TranslationRequest request)
        {
            return new RegionTranslation
            {
               
                   id = request.id,
                   Title = request.Title,
                EntityId = request.EntityId,
                   Lang = request.Lang
            };
        
        }

        protected override TranslationResponse MapToResponse(RegionTranslation model)
        {
            return new TranslationResponse
            {
                id = model.id,
                Title = model.Title,
                EntityId = model.EntityId,
                Lang = model.Lang
              
            };
        }
    }
}