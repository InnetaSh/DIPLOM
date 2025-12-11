using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using TranslationApiService.Models.Location;
using TranslationApiService.Models.Offer;
using TranslationApiService.Service.Offer.Interface;
using TranslationApiService.View;


namespace TranslationApiService.Controllers
{


    public class OfferController : TranslationEntityControllerBase<OfferTranslation, TranslationResponse, TranslationRequest>
    {
        public OfferController(IOfferService offerService, IRabbitMqService mqService)
            : base(offerService, mqService)
        {
        }



        protected override OfferTranslation MapToModel(TranslationRequest request)
        {
            return new OfferTranslation
            {

                id = request.id,
                Title = request.Title,
                Description = request.Description,
                EntityId = request.EntityId,
                Lang = request.Lang
            };

        }

        protected override TranslationResponse MapToResponse(OfferTranslation model)
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