using LocationContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferContracts;
using OfferContracts.RentObj;
using ReviewContracts;
using System.ComponentModel.DataAnnotations;
using TranslationContracts;
using UserContracts;
using WebApiGetway.Helpers;
using WebApiGetway.Service.Interfase;
using static System.Net.Mime.MediaTypeNames;
using static WebApiGetway.Controllers.BffController;

namespace WebApiGetway.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("offers")]
    public class OfferBffController : ControllerBase
    {
        private readonly IOfferBffService _offerService;
        private readonly IUserBffService _userService;
        public OfferBffController(IOfferBffService offerService, IUserBffService userService)
        {
            _offerService = offerService;
            _userService = userService;
        }


        //===============================================================================================================
        //           PARAMS CATEGORIES WITH PARAMS AND TRANSLATION
        //===============================================================================================================
        [HttpGet("param-categories")]
        public async Task<ActionResult<IEnumerable<ParamsCategoryResponse>>> GetMainParamCategory(
            [FromQuery] string lang)
        {
            var result = await _offerService.GetAllParamCategoryWithParamsAndTranslations(lang);
            return Ok(result);
        }

        //===============================================================================================================
        //            PARAMS WITH TRANSLATIONS
        //===============================================================================================================
        [HttpGet("param-items")]
        public async Task<ActionResult<IEnumerable<ParamItemResponse>>> GetMainParamItem(
            [FromQuery] string lang)
        {
            var result = await _offerService.GetMainParamItem(lang);
            return Ok(result);
        }

       

        //===============================================================================================================
        //      SEARCHES FOR AVAILABLE OFFERS (HOTELS, APARTMENTS, ETC.) based on parameters
        //===============================================================================================================

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<OfferResponse>>> GetOffersBySearchCriteria(
             [FromQuery] string lang,
             [FromQuery] int? cityId,
             [FromQuery] int? regionId,
             [FromQuery] int? countryId,
             [FromQuery] DateOnly? startDate,
             [FromQuery] DateOnly? endDate,
             [FromQuery] int adults = 1,
             [FromQuery] int children = 0,
             [FromQuery] int rooms = 1,
             [FromQuery] string? paramItemFilters = null)
        {
            int userId = -1;
            decimal discount = 0m;
            if (User.Identity?.IsAuthenticated == true)
            {
                userId = User.GetUserId();
                var user = await _userService.GetById(userId);
                discount = user?.Discount ?? 0m;
            }
            var result = await _offerService.GetOffersBySearchCriteria(
                userId: userId,
                userDiscountPercent: discount,
                lang: lang,
                cityId: cityId,
                regionId: regionId,
                countryId: countryId,
                startDate: startDate,
                endDate: endDate,
                adults: adults,
                children: children,
                rooms: rooms,
                paramItemFilters: paramItemFilters
            );
            return Ok(result);
        }

        //===============================================================================================================
        //      GET FULL OFFER DATA BY offerId WITH TRANSLATIONS AND RATINGS
        //===============================================================================================================
        [HttpGet("{offerId}")]
        public async Task<ActionResult<OfferResponse>> GetFullOfferById(
          [FromRoute] int offerId,
          [FromQuery] string lang,
          [FromQuery] DateOnly? startDate,
          [FromQuery] DateOnly? endDate,
          [FromQuery] int adults = 1,
          [FromQuery] int children = 0,
          [FromQuery] int rooms = 1)
        {
            int userId = -1;
            decimal discount = 0m;
            string? accessToken = null;
            if (User.Identity?.IsAuthenticated == true)
            {
                accessToken = HttpContext.Request.Headers["Authorization"].ToString();

                if (!string.IsNullOrEmpty(accessToken))
                {
                    var user = await _userService.GetMeAsync(lang, accessToken);
                    userId = user?.id ?? -1;
                    discount = user?.Discount ?? 0m;
                }
            }
            var result = await _offerService.GetFullOfferById(
                accessToken: accessToken, 
                userId: userId,
                offerId: offerId,
                lang: lang,
                startDate: startDate,
                endDate: endDate,
                adults: adults,
                children: children,
                rooms: rooms,
                userDiscountPercent: discount
            );
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        //===============================================================================================================
        //      GET FULL OFFER DETAILS BY offerId AND orderId FOR USER HISTORY 
        //===============================================================================================================
        [HttpGet("history/{offerId}/{orderId}")]
        public async Task<ActionResult<OfferResponse>> GetOfferByIdForOrderHistory(
          [FromRoute] int offerId,
          [FromRoute] int orderId,
          [FromQuery] string lang = "en")
        {
            var result = await _offerService.GetOfferByIdForOrderHistory(
                offerId: offerId,
                orderId: orderId,
                lang: lang
            );
            if (result == null)
                return NotFound();
            return Ok(result);
        }


        //===============================================================================================================
        //		CREATE OFFER
        //===============================================================================================================

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> CreateOffer(
             [FromBody, Required] OfferRequest Offer,
             [FromQuery] string lang)

        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            var userId = User.GetUserId();
            var result = await _offerService.CreateOffer(
                userId: userId,
                offer: Offer,
                lang: lang,
                accessToken: accessToken
           );
            if (result == -1)
                return BadRequest("Offer creation failed.");
            return Ok(result);
        }

        //===============================================================================================================
        //		UPDATE OFFER
        //===============================================================================================================
        [HttpPut("{offerId}")]
        [Authorize]
        public async Task<ActionResult<OfferResponse>> UpdateOffer(
             [FromRoute] int offerId,
             [FromQuery] string lang,
             [FromBody, Required] OfferRequest offer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            var result = await _offerService.UpdateOffer(
               offerId,
               offer: offer,
               lang: lang,
               accessToken: accessToken
          );
            return Ok(result);
        }

        //===============================================================================================================
        //		UPDATE OFFER PRICE
        //===============================================================================================================


        [HttpPut("{offerId}/price")]
        [Authorize]
        public async Task<ActionResult<int>> UpdateOfferPrice(
             [FromRoute] int offerId,
             [FromQuery] string lang,
             [FromBody, Required] UpdateOfferPriceRequest request)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            var result = await _offerService.UpdateOfferPrice(
               offerId: offerId,
               updateOfferPriceRequest: request,
               lang: lang,
               accessToken: accessToken
          );
            return Ok(result);
        }

        //===============================================================================================================
        //		UPDATE OFFER TEXT
        //===============================================================================================================

        [HttpPut("{offerId}/text")]
        [Authorize]
        public async Task<ActionResult<int>> UpdateTextOffer(
             [FromRoute] int offerId,
             [FromQuery] string lang,
             [FromBody, Required] TranslationRequest request)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            request.EntityId = offerId;
            var result = await _offerService.UpdateTextOffer(
               request: request,
               lang: lang,
               accessToken: accessToken
          );
            return Ok(result);
        }

        //===============================================================================================================
        //		ADD OFFER IMAGES
        //===============================================================================================================

        [HttpPost("{offerId}/img")]
        [Authorize]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<IEnumerable<string>>> AddImageOffer(
         [FromRoute] int offerId,
         [FromForm] UploadImagesRequest request
            )
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            var result = await _offerService.AddImageOffer(
            offerId: offerId,
            files: request.Files,
            accessToken: accessToken
        );
            return Ok(result);
        }

        //===============================================================================================================
        //		UPDATE OFFER IMAGE
        //===============================================================================================================

        [HttpPost("{offerId}/img/{imageId}")]
        [Authorize]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<UpdateImageOfferResponse>> UpdateImageOffer(
               [FromRoute] int offerId,
               [FromRoute] int imageId,
               [FromForm] UpdateImageOfferRequest request
          )
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            var result = await _offerService.UpdateImageOffer(
               offerId: offerId,
               imageId: imageId,
               file: request.File,
               accessToken: accessToken);
            return Ok(result);
        }

        //===============================================================================================================
        //		DELETE OFFER IMAGE
        //===============================================================================================================
        [HttpDelete("{offerId}/img/{imageId}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteImageOffer(
            [FromRoute] int offerId,
            [FromRoute] int imageId
       )
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            var result = await _offerService.DeleteImageOffer(
              offerId: offerId,
              imageId: imageId,
              accessToken: accessToken);

            return Ok(result);
        }

        //===============================================================================================================
        //		TOGGLE OFFER BLOCK STATUS
        //===============================================================================================================

        [HttpPut("{offerId}/isblock")]
        [Authorize]
        public async Task<ActionResult<bool>> SetOfferBlockStatus(
            [FromRoute] int offerId,
            [FromQuery] bool block)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(accessToken))
                return Unauthorized();

            var result = await _offerService.SetOfferBlockStatus(
             offerId: offerId,
             block: block,
             accessToken: accessToken
             );

            return Ok(result);
        }

        //===============================================================================================================
        //		TOP OFFERS FOR PERIOD (WEEK / MONTH / YEAR)
        //===============================================================================================================


        [HttpGet("populars")]
        public async Task<ActionResult<IEnumerable<OfferResponseForPupularList>>> GetPopularTopOffer(
            [FromQuery] string period,
            [FromQuery] int limit,
            [FromQuery] string lang)
        {
            var result = await _offerService.GetPopularTopOffer(
                         period: period,
                         limit: limit,
                         lang: lang);

            return Ok(result);
        }
    }
}
