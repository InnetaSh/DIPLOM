using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using TranslationApiService.Models.Location;
using TranslationApiService.Models.Offer;
using TranslationApiService.Service.Offer.Interface;
using TranslationContracts;


namespace TranslationApiService.Controllers
{


    public class ParamItemTranslationController : TranslationEntityControllerBase<ParamItemTranslation, TranslationResponse, TranslationRequest>
    {
        public ParamItemTranslationController(IParamItemService paramItemService, IRabbitMqService mqService)
            : base(paramItemService, mqService)
        {
        }



        protected override ParamItemTranslation MapToModel(TranslationRequest request)
        {
            return new ParamItemTranslation
            {

                id = request.id,
                Title = request.Title,
                EntityId = request.EntityId,
                Lang = request.Lang
            };

        }

        protected override TranslationResponse MapToResponse(ParamItemTranslation model)
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