using Globals.Abstractions;
using Globals.Controllers;
using TranslationApiService.Models.Attraction;
using TranslationApiService.Service.Attraction.Interface;
using TranslationContracts;


namespace TranslationApiService.Controllers
{

    
    public class AttractionTranslationController : TranslationEntityControllerBase<AttractionTranslation, TranslationResponse, TranslationRequest>
    {
        public AttractionTranslationController(IAttractionService attractionService, IRabbitMqService mqService)
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
                   Lang = request.Lang,
                   Address = request.Address
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
                Lang = model.Lang,
                Address = model.Address
            };
        }
    }
}