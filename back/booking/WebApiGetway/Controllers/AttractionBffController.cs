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

        [HttpGet("from-cities/{cityId}/attractions/{lang}")]
        public Task<IEnumerable<AttractionResponse>> GetAllAttractionByCityId(
            [FromRoute] int cityId,
            [FromRoute] string lang)
           => _attractionService.GetAllAttractionByCityId(cityId, lang);

        //===============================================================================================================
        //      GET ATTRACTIONS BY  attractionId
        //===============================================================================================================

        [HttpGet("{attractionId}/{lang}")]
        public Task<AttractionResponse> GetAttractionById(
            [FromRoute] int attractionId,
            [FromRoute] string lang)
             => _attractionService.GetAttractionById(attractionId, lang);


        //===============================================================================================================
        //          GET NEAREST ATTRACTIONS
        //===============================================================================================================

        [HttpGet("near/{offerId}/{distance}/{lang}")]
        public Task<IEnumerable<AttractionResponse>> GetNearAttractionsByIdWithDistance(
            [FromRoute] int offerId,
            [FromRoute] decimal distance,
            [FromRoute] string lang)
             => _attractionService.GetNearAttractionsByIdWithDistance(offerId, distance, lang);

       
    }
}
