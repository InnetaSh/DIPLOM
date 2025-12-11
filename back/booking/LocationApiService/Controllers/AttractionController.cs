using Globals.Abstractions;
using Globals.Controllers;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;
using LocationApiService.View;
using Microsoft.AspNetCore.Mvc;

namespace LocationApiService.Controllers
{
    public class AttractionController : EntityControllerBase<Attraction, AttractionResponse, AttractionRequest>
    {
        public AttractionController(IAttractionService attractionService, IRabbitMqService mqService)
            : base(attractionService, mqService)
        {
        }


        protected override Attraction MapToModel(AttractionRequest request)
        {
            return AttractionRequest.MapToModel(request);
        }


        protected override AttractionResponse MapToResponse(Attraction model)
        {
            return AttractionResponse.MapToResponse(model);

        }
    }
}