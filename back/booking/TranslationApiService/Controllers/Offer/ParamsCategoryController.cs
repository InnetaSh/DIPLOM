using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using TranslationApiService.Models.Location;
using TranslationApiService.Models.Offer;
using TranslationApiService.Service.Offer.Interface;
using TranslationApiService.View;


namespace TranslationApiService.Controllers
{


    public class ParamCategoryController : TranslationEntityControllerBase<ParamsCategoryTranslation, TranslationResponse, TranslationRequest>
    {
        public ParamCategoryController(IParamsCategoryService paramCategoryService, IRabbitMqService mqService)
            : base(paramCategoryService, mqService)
        {
        }



        protected override ParamsCategoryTranslation MapToModel(TranslationRequest request)
        {
            return new ParamsCategoryTranslation
            {

                id = request.id,
                Title = request.Title,
                EntityId = request.EntityId,
                Lang = request.Lang
            };

        }

        protected override TranslationResponse MapToResponse(ParamsCategoryTranslation model)
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