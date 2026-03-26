using AttractionContracts;
using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using TranslationContracts;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Controllers
{
    [ApiController]
    [Route("attractions")]
    public class AttractionBffController : ControllerBase
    {
        private readonly IAttractionBffService _attractionService;
        public AttractionBffController(IAttractionBffService attractionService)
        {
            _attractionService = attractionService;
        }


        //===============================================================================================================
        //     	GET ALL CITY ATTRACTIONS BY CityId
        //===============================================================================================================

        [HttpGet("from-cities/{cityId}/attraction}")]
        public Task<IEnumerable<AttractionResponse>> GetAllAttractionByCityId(
            [FromRoute] int cityId,
            [FromQuery] string lang)
           => _attractionService.GetAllAttractionByCityId(cityId, lang);

        //===============================================================================================================
        //      GET ATTRACTIONS BY  attractionId
        //===============================================================================================================

        [HttpGet("{attractionId}")]
        public Task<AttractionResponse> GetAttractionById(
            [FromRoute] int attractionId,
            [FromQuery] string lang)
             => _attractionService.GetAttractionById(attractionId, lang);


        //===============================================================================================================
        //          GET NEAREST ATTRACTIONS
        //===============================================================================================================

        [HttpGet("near/{offerId}/{distance}")]
        public Task<IEnumerable<AttractionResponse>> GetNearAttractionsByIdWithDistance(
            [FromRoute] int offerId,
            [FromRoute] decimal distance,
            [FromQuery] string lang)
             => _attractionService.GetNearAttractionsByIdWithDistance(offerId, distance, lang);

       
    }
}
