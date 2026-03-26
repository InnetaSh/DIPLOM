using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using TranslationApiService.Models.Location;
using TranslationApiService.Service.Location.Interface;
using TranslationContracts;


namespace TranslationApiService.Controllers
{
        public class DistrictTranslationController : TranslationEntityControllerBase<DistrictTranslation, TranslationResponse, TranslationRequest>
        {
            public DistrictTranslationController(IDistrictService districrService, IRabbitMqService mqService)
                : base(districrService, mqService)
            {
            }



            protected override DistrictTranslation MapToModel(TranslationRequest request)
            {
                return new DistrictTranslation
                {

                    id = request.id,
                    Title = request.Title,
                    EntityId = request.EntityId,
                    Lang = request.Lang,
                };

            }

            protected override TranslationResponse MapToResponse(DistrictTranslation model)
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