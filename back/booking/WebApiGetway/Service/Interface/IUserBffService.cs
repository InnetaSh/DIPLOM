using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using OfferContracts;
using System.Threading.Tasks;
using TranslationContracts;
using UserContracts;

namespace WebApiGetway.Service.Interfase
{
    public interface IUserBffService
    {
        Task<UserResponse> GetById(int userId);
        Task<IEnumerable<UserResponse>> GetAll(string accessToken);
        Task<UserResponse> GetByIdForAdmin(int userId, string accessToken);
        Task<UserResponse> GetByEmail(string email, string accessToken);
        Task<UserResponse> GetMeAsync(string lang, string accessToken);

        Task<IEnumerable<OfferResponse>> GetMyOffers(string lang, string accessToken);
        Task<IEnumerable<OfferResponse>> GetMyOffersByCityId(int cityId, string lang, string accessToken);
        Task<IEnumerable<OfferResponse>> GetMyOffersByCountryId(int countryId, string lang, string accessToken);
        //=====================================================================

        Task<bool> AddOfferToClientFavorite(int offerId, string accessToken);

        Task<IEnumerable<HistoryOfferLinkResponse>> GetOffersFromClientHistory(string lang, int userId, string accessToken);
        Task<IEnumerable<int>> GetOffersIdFromClientHistory(string lang, string accessToken);
        Task<IEnumerable<int>> HasPendingOrder(int userId);

        //=====================================================================

        Task<GoogleLoginResponse> GoogleLogin(GoogleLoginRequest request);
        Task<LoginResponse> Login(LoginRequest request);
        //=====================================================================

        Task<RegisterResponse> RegisterClient(RegisterRequest request);
        Task<RegisterResponse> RegisterOwner(RegisterRequest request);
        //=====================================================================
        Task<UserResponse> UpdateMe(UserRequest request, int userId, string accessToken);
        Task<bool> ChangePassword(ChangePasswordRequest request, int userId, string accessToken);
        Task<bool> ChangeEmail(ChangeEmailRequest request, int userId, string accessToken);
        //=====================================================================
        Task<bool> DeleteAsync(int userId, string accessToken);
    }

}
