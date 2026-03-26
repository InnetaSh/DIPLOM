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
        Task<IEnumerable<UserResponse>> GetAll();
        Task<UserResponse> GetById(int userId);
        Task<UserResponse> GetByEmail(string email);
        Task<UserResponse> GetMeAsync(string lang);

        Task<IEnumerable<OfferResponse>> GetMyOffers(string lang);
        Task<IEnumerable<OfferResponse>> GetMyOffersByCityId(int cityId, string lang);
        Task<IEnumerable<OfferResponse>> GetMyOffersByCountryId(int countryId, string lang);
        //=====================================================================

        Task<bool> AddOfferToClientFavorite(int offerId);

        Task<IEnumerable<HistoryOfferLinkResponse>> GetOffersFromClientHistory(string lang, int userId);
        Task<IEnumerable<int>> GetOffersIdFromClientHistory(string lang);
        Task<IEnumerable<int>> HasPendingOrder(int userId);

        //=====================================================================

        Task<GoogleLoginResponse> GoogleLogin(GoogleLoginRequest request);
        Task<LoginResponse> Login(LoginRequest request);
        //=====================================================================

        Task<RegisterResponse> RegisterClient(RegisterRequest request);
        Task<RegisterResponse> RegisterOwner(RegisterRequest request);
        //=====================================================================
        Task<UserResponse> UpdateMe(UserRequest request, int userId);
        Task<bool> ChangePassword(ChangePasswordRequest request, int userId);
        Task<bool> ChangeEmail(ChangeEmailRequest request, int userId);
        //=====================================================================
        Task<bool> DeleteAsync(int userId);
    }

}
