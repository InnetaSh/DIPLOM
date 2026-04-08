using Globals.Clients;
using LocationContracts;
using Microsoft.AspNetCore.Mvc;
using ReviewContracts;
using System.Net.Http.Json;
using TranslationContracts;
using UserContracts;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Service.Interfase;

namespace WebApiGetway.Clients
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {
        //private readonly HttpClient _client;

        //public LocationApiClient(HttpClient client)
        //{
        //    _client = client;
        //}
        public UserApiClient(HttpClient client, ILogger<UserApiClient> logger)
       : base(client, logger) { }


        //===============================================================================================================
        //  GET METHODS BY userId
        //===============================================================================================================
        public async Task<UserResponse> GetUserByIdAsync(int userId)
        {
            var result = await GetAsync<UserResponse>($"/api/user/{userId}");
            return result ?? new UserResponse();
        }

        //===========================================================================================
        //  GET METHODS (для авторизованного пользователя) - получить полную информацию о себе
        //===========================================================================================

        public Task<UserResponse?> GetMeAsync(string accessToken)
        {
            return GetAsync<UserResponse>(
                "/api/user/me",
                headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );
        }
        //===========================================================================================
        //  GET METHODS (для админа) - получить всех пользователей
        //===========================================================================================

        public async Task<IEnumerable<UserResponse?>> GetAll(string accessToken)
        {
            var result = await GetAsync<IEnumerable<UserResponse>>(
                $"/api/user/get-all",
                 headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );
            return result ?? Enumerable.Empty<UserResponse>();
        }
        //===========================================================================================
        //  GET METHODS (для админа) - получить полную информацию о пользователе по Id
        //===========================================================================================

        public async Task<UserResponse?> GetByIdForAdmin(int userId, string accessToken)
        {
            var result = await GetAsync<UserResponse>(
                $"/api/user/admin/get/userfullinfo/{userId}",
                 headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );
            return result ?? new UserResponse();
        }

        //===========================================================================================
        //  GET METHODS (для админа) - получить полную информацию о пользователе по email
        //===========================================================================================

        public async Task<UserResponse?> GetByEmail(string email, string accessToken)
        {
            var result = await GetAsync<UserResponse>(
                $"/api/user/admin/get/userfullinfo/by-email/{email}",
                 headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );
            return result ?? new UserResponse();
        }



        // ==========================================================================================
        //  GET METHODS  получить offers из истории пользователя
        // ==========================================================================================

        public async Task<IEnumerable<HistoryOfferLinkResponse>> GetOffersFromClientHistory(string accessToken)
        {
            var result = await GetAsync<IEnumerable<HistoryOfferLinkResponse>>(
                "/api/user/me/history/get/offers",
                 headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );

            return result ?? Enumerable.Empty<HistoryOfferLinkResponse>();
        }
        // ==========================================================================================
        //    ADD METHODS offer в историю пользователя
        // ==========================================================================================

        public async Task<IEnumerable<HistoryOfferLinkResponse>> AddOffersToClientHistory(int offerId, string accessToken)
        {
            var result = await PostAsync<IEnumerable<HistoryOfferLinkResponse>>(
                $"/api/user/me/history/add/offer/{offerId}",
                new {},
                 headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );

            return result ?? Enumerable.Empty<HistoryOfferLinkResponse>();
        }



        // ==========================================================================================
        //      ADD METHODS в избранное пользователя
        // ==========================================================================================

        public async Task<bool> AddOfferToFavoriteForUserAsync(int offerId, string accessToken)
        {
            try
            {
                await PostAsync<UserResponse>(
                    $"/api/user/me/isfavorite/add/offer/{offerId}",
                    offerId,
                     headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );

                return true;
            }
            catch
            {
                return false;
            }
           
        }



        // ==========================================================================================
        //   ADD METHODS  добавить в список обьявлений  owner          
        // ==========================================================================================
        public async Task<bool> AddOfferToClient(int offerId, string accessToken)
        {
            var result = await PostAsync<bool>(
                $"/api/user/owner/offers/add/{offerId}",
                offerId,
                     headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );

            return result;
        }

        //===========================================================================================
        //       ADD METHODS добавить ссылки на заказ for user
        //===========================================================================================
        public async Task<bool> AddOrderToUsersOrderList(int orderId, string accessToken)
        {
            return await PostAsync<bool>(
                $"/api/user/client/orders/add/{orderId}",
                new { },
            headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );
        }


        // ==========================================================================================
        //      Valid METHODS : принадлежит ли offer текущему владельцу (userId получает сам контроллер)
        // ==========================================================================================
        public async Task<bool> ValidOfferIdByOwner(int offerId, string accessToken)
        {
            var result = await GetAsync<bool>(
                $"/api/user/valid/offers/{offerId}",
                headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );

            return result;
        }


        // ==========================================================================================
        //       Valid METHODS: принадлежит ли offer текущему владельцу
        // ==========================================================================================

        public async Task<bool> ValidOffer(int offerId)
        {
            var result = await GetAsync<bool>(
             $"/api/user/valid/offers/{offerId}" );

            return result;
        }
        // ==========================================================================================
        //		UPDATE USER DISCOUNT BY ID
        // ==========================================================================================
        public async Task<bool> UpdateDiscount(int userId, decimal discountCount)
        {
            var result = await PostAsync<bool>(
                $"/api/user/update/discount/{userId}/{discountCount}",
                new { }
            );

            return result;
        }

        // ==========================================================================================
        //      GOOGLE LOGIN
        // ==========================================================================================
        public async Task<GoogleLoginResponse> GoogleLogin(GoogleLoginRequest request)
        {
            var result = await PostAsync<GoogleLoginResponse>(
                $"/api/auth/google",
                request
            );

            return result ?? new GoogleLoginResponse();
        }

        //===========================================================================================
        //  AUTH METHODS - LOGIN
        //===========================================================================================
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var result = await PostAsync<LoginResponse>(
                $"/api/auth/login",
                request
            );

            return result ?? new LoginResponse();
        }

        //===========================================================================================
        //  REGISTRATION METHODS - REGISTER
        //===========================================================================================
        public async Task<RegisterResponse> RegisterClient(RegisterRequest request)
        {
            var result = await PostAsync<RegisterResponse>(
                $"/api/auth/register/client",
                request
            );

            return result ?? new RegisterResponse();
        }

        //===========================================================================================

        public async Task<RegisterResponse> RegisterOwner(RegisterRequest request)
        {
            var result = await PostAsync<RegisterResponse>(
                $"/api/auth/register/owner",
                request
            );

            return result ?? new RegisterResponse();
        }


        //===========================================================================================
        //      UPDATE METHODS 
        //===========================================================================================
        public async Task<UserResponse> UpdateMe(UserRequest request, string accessToken)
        {
            var result = await PostAsync<UserResponse>(
                $"/api/user/me/update",
                request,
                headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );

            return result ?? new UserResponse();
        }


        //===========================================================================================
        public async Task<bool> ChangePassword(ChangePasswordRequest request, string accessToken)
        {
            var result = await PostAsync<bool>(
                $"/api/user/me/change-password",
                request,
                headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );

            return result;
        }
        //===========================================================================================
        public async Task<bool> ChangeEmail(ChangeEmailRequest request, string accessToken)
        {
            var result = await PostAsync<bool>(
                $"/api/user/me/change-email",
                request,
                headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );

            return result;
        }

        //===========================================================================================
        //      DELETE METHODS 
        //===========================================================================================
        public async Task<bool> DeleteAsync(int userId, string accessToken)
        {
            var result = await DeleteAsync<bool>(
                $"/api/auth/delete/{userId}",
                  headers: new Dictionary<string, string>
                {
                    { "Authorization", accessToken }
                }
            );

            return result;
        }
    }
}
