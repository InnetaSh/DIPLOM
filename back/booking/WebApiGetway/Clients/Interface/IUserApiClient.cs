using LocationContracts;
using TranslationContracts;
using UserContracts;

namespace WebApiGetway.Clients.Interface
{
    public interface IUserApiClient
    {
        Task<UserResponse?> GetUserByIdAsync(int userId);
        Task<UserResponse?> GetMeAsync();
        Task<IEnumerable<UserResponse?>> GetAll();
        Task<UserResponse?> GetById(int userId);
        Task<UserResponse?> GetByEmail(string email);
        Task<IEnumerable<HistoryOfferLinkResponse>> GetOffersFromClientHistory();
        Task<IEnumerable<HistoryOfferLinkResponse>> AddOffersToClientHistory(int offerId);

        //-------------------------------------------------------------------------------------
        Task<bool> AddOfferToFavoriteForUserAsync(int offerId);
        Task<bool> AddOfferToClient(int offerId);
        Task<bool> AddOrderToUsersOrderList(int orderId);

        //-------------------------------------------------------------------------------------


        Task<bool> ValidOfferIdByOwner(int offerId);
      
        Task<bool> ValidOffer(int offerId);
        Task<bool> UpdateDiscount(int userId, decimal discountCount);
        //-------------------------------------------------------------------------------------

        Task<GoogleLoginResponse> GoogleLogin(GoogleLoginRequest request);
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegisterResponse> RegisterClient(RegisterRequest request);
        Task<RegisterResponse> RegisterOwner(RegisterRequest request);
        //-------------------------------------------------------------------------------------

        Task<UserResponse> UpdateMe(UserRequest request);
        Task<bool> ChangePassword(ChangePasswordRequest request);

        Task<bool> ChangeEmail(ChangeEmailRequest request);

        //-------------------------------------------------------------------------------------
        Task<bool> DeleteAsync(int userId);
    }
}
