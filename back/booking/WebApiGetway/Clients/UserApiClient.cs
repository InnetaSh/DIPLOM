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
        public Task<UserResponse?> GetUserByIdAsync(int userId)
        {
            return GetAsync<UserResponse>($"/api/User/{userId}");
        }

        //===========================================================================================
        //  GET METHODS (для авторизованного пользователя) - получить полную информацию о себе
        //===========================================================================================

        public Task<UserResponse?> GetMeAsync()
        {
            return GetAsync<UserResponse>($"/api/User/me");
        }
        //===========================================================================================
        //  GET METHODS (для админа) - получить всех пользователей
        //===========================================================================================

        public async Task<IEnumerable<UserResponse?>> GetAll()
        {
            var result = await GetAsync<IEnumerable<UserResponse>>($"/api/User/get-all");
            return result ?? Enumerable.Empty<UserResponse>();
        }
        //===========================================================================================
        //  GET METHODS (для админа) - получить полную информацию о пользователе по Id
        //===========================================================================================

        public async Task<UserResponse?> GetById(int userId)
        {
            var result = await GetAsync<UserResponse>($"/api/User/admin/get/userfullinfo/{userId}");
            return result ?? new UserResponse();
        }

        //===========================================================================================
        //  GET METHODS (для админа) - получить полную информацию о пользователе по email
        //===========================================================================================

        public async Task<UserResponse?> GetByEmail(string email)
        {
            var result = await GetAsync<UserResponse>($"/api/User/admin/get/userfullinfo/{email}");
            return result ?? new UserResponse();
        }



        // ==========================================================================================
        //  GET METHODS  получить offers из истории пользователя
        // ==========================================================================================

        public async Task<IEnumerable<HistoryOfferLinkResponse>> GetOffersFromClientHistory()
        {
            var result = await GetAsync<IEnumerable<HistoryOfferLinkResponse>>(
                "/api/User/me/history/get/offers"
            );

            return result ?? Enumerable.Empty<HistoryOfferLinkResponse>();
        }
        // ==========================================================================================
        //    ADD METHODS offer в историю пользователя
        // ==========================================================================================

        public async Task<IEnumerable<HistoryOfferLinkResponse>> AddOffersToClientHistory(int offerId)
        {
            var result = await PostAsync<IEnumerable<HistoryOfferLinkResponse>>(
                $"/api/User/me/history/add/offer/{offerId}",
                new {}
            );

            return result ?? Enumerable.Empty<HistoryOfferLinkResponse>();
        }



        // ==========================================================================================
        //      ADD METHODS в избранное пользователя
        // ==========================================================================================

        public async Task<bool> AddOfferToFavoriteForUserAsync(int offerId)
        {
            try
            {
                await PostAsync<UserResponse>($"/api/user/me/isfavorite/add/offer/{offerId}", offerId);

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
        public async Task<bool> AddOfferToClient(int offerId)
        {
            var result = await PostAsync<bool>(
                $"/api/User/owner/offers/add/{offerId}",
                offerId 
            );

            return result;
        }

        //===========================================================================================
        //       ADD METHODS добавить ссылки на заказ for user
        //===========================================================================================
        public async Task<bool> AddOrderToUsersOrderList(int orderId)
        {
            return await PostAsync<bool>(
                $"/api/user/client/orders/add/{orderId}",
                new { }
            );
        }


        // ==========================================================================================
        //      Valid METHODS : принадлежит ли offer текущему владельцу (userId получает сам контроллер)
        // ==========================================================================================
        public async Task<bool> ValidOfferIdByOwner(int offerId)
        {
            var result = await PostAsync<bool>(
                $"/api/User/valid/offers/{offerId}",
                offerId
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
        public async Task<UserResponse> UpdateMe(UserRequest request)
        {
            var result = await PostAsync<UserResponse>(
                $"/api/user/me/update",
                request
            );

            return result ?? new UserResponse();
        }


        //===========================================================================================
        public async Task<bool> ChangePassword(ChangePasswordRequest request)
        {
            var result = await PostAsync<bool>(
                $"/api/user/me/change-password",
                request
            );

            return result;
        }
        //===========================================================================================
        public async Task<bool> ChangeEmail(ChangeEmailRequest request)
        {
            var result = await PostAsync<bool>(
                $"/api/user/me/change-email",
                request
            );

            return result;
        }

        //===========================================================================================
        //      DELETE METHODS 
        //===========================================================================================
        public async Task<bool> DeleteAsync(int userId)
        {
            var result = await DeleteAsync<bool>(
                $"/api/auth/delete/{userId}");

            return result;
        }
    }
}
