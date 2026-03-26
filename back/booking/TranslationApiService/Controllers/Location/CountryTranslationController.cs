using Globals.Abstractions;
using Globals.Controllers;
using Microsoft.AspNetCore.Mvc;
using TranslationApiService.Models.Location;
using TranslationApiService.Service.Location.Interface;
using TranslationContracts;


namespace TranslationApiService.Controllers
{

    public class CountryTranslationController : TranslationEntityControllerBase<CountryTranslation, TranslationResponse, TranslationRequest>
    {
        public CountryTranslationController(ICountryService countryIdService, IRabbitMqService mqService)
            : base(countryIdService, mqService)
        {
        }



        protected override CountryTranslation MapToModel(TranslationRequest request)
        {
            return new CountryTranslation
            {

                id = request.id,
                Title = request.Title,
                EntityId = request.EntityId,
                Lang = request.Lang,
            };

        }

        protected override TranslationResponse MapToResponse(CountryTranslation model)
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