using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using TranslationApiService.Models.Location;
using TranslationApiService.Service.Location.Interface;
using TranslationApiService.View;


namespace TranslationApiService.Controllers
{

    
    public class AttractionController : TranslationEntityControllerBase<AttractionTranslation, TranslationResponse, TranslationRequest>
    {
        public AttractionController(IAttractionService attractionService, IRabbitMqService mqService)
            : base(attractionService, mqService)
                {
                }



        protected override AttractionTranslation MapToModel(TranslationRequest request)
        {
            return new AttractionTranslation
            {
               
                   id = request.id,
                   Title = request.Title,
                   Description = request.Description,
                EntityId = request.EntityId,
                   Lang = request.Lang
            };
        
        }

        protected override TranslationResponse MapToResponse(AttractionTranslation model)
        {
            return new TranslationResponse
            {
                id = model.id,
                Title = model.Title,
                Description = model.Description,
                EntityId = model.EntityId,
                Lang = model.Lang
              
            };
        }
    }
}