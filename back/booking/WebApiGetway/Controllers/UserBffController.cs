using AttractionContracts;
using LocationContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferContracts;
using OrderContracts;
using ReviewContracts;
using System.ComponentModel.DataAnnotations;
using TranslationContracts;
using UserContracts;
using WebApiGetway.Clients;
using WebApiGetway.Helpers;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("users")]
    public class UserBffController : ControllerBase
    {
        private readonly IOrderBffService _orderService;
        private readonly IUserBffService _userService;
        public UserBffController(
            IOrderBffService orderService,
            IUserBffService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }


        //===============================================================================================================
        //		(FOR ADMIN) - GET ALL USERS
        //===============================================================================================================
        [HttpGet("admin/all")]
        [Authorize(Roles = "Admin,SuperAdmin")]

        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAll()
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }


        //===========================================================================================
        //		(FOR ADMIN) - GET FULL USER INFORMATION BY userId
        //===========================================================================================
        
        [HttpGet("admin/by-id/{userId}")]
        [Authorize(Roles = "Admin,SuperAdmin")]

        public async Task<ActionResult<UserResponse>> GetById(
             [FromRoute] int userId)
        {
            var result = await _userService.GetById(userId);
            return Ok(result);
        }

        //===========================================================================================
        //		(FOR ADMIN) - GET FULL USER INFORMATION BY EMAIL
        //===========================================================================================

        [HttpGet("admin/by-email")]
        [Authorize(Roles = "Admin,SuperAdmin")]

        public async Task<ActionResult<UserResponse>> GetByEmail(
             [FromQuery] string email)
        {
            var result = await _userService.GetByEmail(email);
            return Ok(result);
        }

        //===========================================================================================
        //		(FOR AUTHORIZED USER) - GET FULL INFORMATION ABOUT CURRENT USER
        //===========================================================================================

        [HttpGet("me")]
        [Authorize]

        public async Task<ActionResult<UserResponse>> GetMeAsync(
             [FromQuery] string lang)
        {
            var result = await _userService.GetMeAsync(lang);
            return Ok(result);
        }


        //===========================================================================================
        //		(FOR AUTHORIZED USER) - GET OFFERS BY ownerId (WITHOUT ADDITIONAL CALCULATIONS)
        //===========================================================================================

        [HttpGet("me/offers")]
        [Authorize]

        public async Task<ActionResult<IEnumerable<OfferResponse>>> GetMyOffers(
             [FromQuery] string lang)
        {
            var result = await _userService.GetMyOffers(lang);
            return Ok(result);
        }

        //===========================================================================================
        //		(FOR AUTHORIZED USER) - GET OFFERS BY ownerId AND cityId (WITHOUT ADDITIONAL CALCULATIONS)
        //===========================================================================================

        [HttpGet("me/offers/by-city")]
        [Authorize]

        public async Task<ActionResult<IEnumerable<OfferResponse>>> GetMyOffersByCityId(
             [FromQuery] int cityId,
             [FromQuery] string lang)
        {
            var result = await _userService.GetMyOffersByCityId(cityId, lang);
            return Ok(result);
        }

        //===========================================================================================
        //		(FOR AUTHORIZED USER) - GET OFFERS BY ownerId AND countryId (WITHOUT ADDITIONAL CALCULATIONS)
        //===========================================================================================

        [HttpGet("me/offers/by-country")]
        [Authorize]

        public async Task<ActionResult<IEnumerable<OfferResponse>>> GetMyOffersByCountryId(
             [FromQuery] int countryId,
             [FromQuery] string lang)
        {
            var result = await _userService.GetMyOffersByCountryId(countryId, lang);
            return Ok(result);
        }

        //===========================================================================================
        //		CHECK IF OWNER HAS PENDING ORDERS
        //===========================================================================================
        
        [HttpGet("me/orders/has-pending")]
        [Authorize]
        public async Task<ActionResult<int>> HasPendingOrder()
        {
            
            var  userId = User.GetUserId();
             
            var result = await _userService.HasPendingOrder(userId);
            return Ok(result);
        }



        //===============================================================================================================
        //		CLIENT: ADD OFFER TO FAVORITES
        //===============================================================================================================

        [HttpPost("me/favorites/{offerId}")]
        [Authorize]

        public async Task<ActionResult<bool>> AddOfferToClientFavorite(
        [FromRoute] int offerId)
        {
            var result = await _userService.AddOfferToClientFavorite(
                offerId: offerId
            );
            if (!result)
                return BadRequest("Offer could not be added to favorites.");
            return Ok(result);
        }

        //===============================================================================================================
        //		CLIENT: GET ALL OFFERS FROM HISTORY
        //===============================================================================================================

        [HttpGet("me/history/{lang}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<HistoryOfferLinkResponse>>> GetOffersFromClientHistory(
          [FromRoute] string lang)
        {
            var userId = User.GetUserId();
            var result = await _userService.GetOffersFromClientHistory(
                userId: userId,
                lang: lang
            );
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        //===============================================================================================================
        //		CLIENT: GET OFFER IDS FROM HISTORY AND FAVORITES
        //===============================================================================================================
        [Authorize]
        [HttpGet("me/history/offersId/{lang}")]
        public async Task<ActionResult<IEnumerable<int>>> GetOffersIdFromClientHistory(
             [FromRoute] string lang)
        {
            var result = await _userService.GetOffersIdFromClientHistory(
                lang: lang
            );
            if (result == null)
                return NotFound();
            return Ok(result);
        }


        // ==========================================================================================
        //		AUTH METHODS - GOOGLE LOGIN
        // ==========================================================================================

        [HttpPost("login/google")]
        public async Task<ActionResult<GoogleLoginResponse>> GoogleLogin(
            [FromBody, Required] GoogleLoginRequest request)
        {
            var result = await _userService.GoogleLogin(
                request: request
            );
            return Ok(result);
        }

        // ==========================================================================================
        //	AUTH METHODS - LOGIN
        // ==========================================================================================

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(
            [FromBody, Required] LoginRequest request)
        {
            var result = await _userService.Login(
                request: request
            );
            return Ok(result);
        }

        //===========================================================================================
        //		REGISTRATION METHODS - REGISTER CLIENT / REGISTER OWNER
        //===========================================================================================
        [HttpPost("register/client")]
        public async Task<ActionResult<RegisterResponse>> RegisterClient(
            [FromBody, Required] RegisterRequest request)
        {
            var result = await _userService.RegisterClient(
                request: request
            );
            return Ok(result);
        }

        [HttpPost("register/owner")]
        public async Task<ActionResult<RegisterResponse>> RegisterOwner(
           [FromBody, Required] RegisterRequest request)
        {
            var result = await _userService.RegisterOwner(
                request: request
            );
            return Ok(result);
        }

        //===========================================================================================
        //		UPDATE ME
        //===========================================================================================

        [HttpPut("me")]
        [Authorize]
        public async Task<ActionResult<UserResponse>> UpdateMe(
           [FromBody, Required] UserRequest request)
        {

            var userId = User.GetUserId();
            var result = await _userService.UpdateMe(
                request: request,
                userId: userId
            );
            return Ok(result);
        }

        //===========================================================================================
        //		UPDATE PASSWORD
        //===========================================================================================

        [HttpPut("me/password")]
        [Authorize]
        public async Task<ActionResult<bool>> ChangePassword(
           [FromBody, Required] ChangePasswordRequest request)
        {
            var userId = User.GetUserId();
            var result = await _userService.ChangePassword(
                request: request,
                userId: userId
            );
            return Ok(result);
        }
        //===========================================================================================
        //		UPDATE EMAIL
        //===========================================================================================

        [HttpPut("me/email")]
        [Authorize]
        public async Task<ActionResult<bool>> ChangeEmail(
           [FromBody, Required] ChangeEmailRequest request)
        {
            var userId = User.GetUserId();
            var result = await _userService.ChangeEmail(
                request: request,
                userId: userId
            );
            return Ok(result);
        }

        //===========================================================================================
        //		(FOR ADMIN) - DELETE USER
        //===========================================================================================
        [HttpDelete("admin/{userId}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<ActionResult<bool>> DeleteAsync(
            [FromRoute] int userId)
        {
            var result = await _userService.DeleteAsync(
                userId: userId
            );
            if (!result) return NotFound(new { Message = $"User {userId} not found or cannot be deleted" });
            return Ok(true);
        }
        //===========================================================================================
        //		(FOR AUTHORIZED USER) - DELETE ME
        //===========================================================================================
        [HttpDelete("me")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteAsync()
        {
            var userId = User.GetUserId();
            var result = await _userService.DeleteAsync(
                userId: userId
            );
            if (!result) 
                return NotFound(new { Message = $"User {userId} not found or cannot be deleted" });
            return Ok(true);
        }


    }
}
