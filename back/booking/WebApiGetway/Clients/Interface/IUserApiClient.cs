using LocationContracts;
using TranslationContracts;
using UserContracts;

namespace WebApiGetway.Clients.Interface
{
    public interface IUserApiClient
    {
        Task<UserResponse?> GetUserByIdAsync(int userId);
        Task<UserResponse?> GetMeAsync(string accessToken);
        Task<IEnumerable<UserResponse?>> GetAll(string accessToken);
        Task<UserResponse?> GetByIdForAdmin(int userId, string accessToken);
        Task<UserResponse?> GetByEmail(string email, string accessToken);
        Task<IEnumerable<HistoryOfferLinkResponse>> GetOffersFromClientHistory(string accessToken);
        Task<IEnumerable<HistoryOfferLinkResponse>> AddOffersToClientHistory(int offerId, string accessToken);

        //-------------------------------------------------------------------------------------
        Task<bool> AddOfferToFavoriteForUserAsync(int offerId, string accessToken);
        Task<bool> AddOfferToClient(int offerId, string accessToken);
        Task<bool> AddOrderToUsersOrderList(int orderId, string accessToken);

        //-------------------------------------------------------------------------------------


        Task<bool> ValidOfferIdByOwner(int offerId, string accessToken);
      
        Task<bool> ValidOffer(int offerId);
        Task<bool> UpdateDiscount(int userId, decimal discountCount);
        //-------------------------------------------------------------------------------------

        Task<GoogleLoginResponse> GoogleLogin(GoogleLoginRequest request);
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegisterResponse> RegisterClient(RegisterRequest request);
        Task<RegisterResponse> RegisterOwner(RegisterRequest request);
        //-------------------------------------------------------------------------------------

        Task<UserResponse> UpdateMe(UserRequest request,string accessToken);
        Task<bool> ChangePassword(ChangePasswordRequest request, string accessToken);

        Task<bool> ChangeEmail(ChangeEmailRequest request, string accessToken);

        //-------------------------------------------------------------------------------------
        Task<bool> DeleteAsync(int userId,string accessToken);
    }
}
