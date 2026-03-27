using Globals.Exceptions;
using Microsoft.AspNetCore.Mvc;
using OfferContracts.RentObj;
using StatisticContracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Controllers;
using WebApiGetway.Service;

namespace WebApiGetway.Helpers
{
    public class HelpersFunctions
    {

        private readonly ITranslationApiClient _translationClient;
        private readonly ILocationApiClient _locationClient;
        private readonly IStatisticApiClient _statisticClient;
        private readonly IOfferApiClient _offerApiClient;
        private readonly IUserApiClient _userApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly IReviewApiClient _reviewApiClient;
        private readonly ILogger<OfferBffService> _logger;

        public HelpersFunctions
                (ITranslationApiClient translationClient,
                ILocationApiClient locationClient,
                IStatisticApiClient statisticClient,
                IUserApiClient userApiClient,
                IOfferApiClient offerApiClient,
                IOrderApiClient orderApiClient,
                IReviewApiClient reviewApiClient,
        ILogger<OfferBffService> logger)
        {
            _translationClient = translationClient;
            _locationClient = locationClient;
            _statisticClient = statisticClient;
            _userApiClient = userApiClient;
            _offerApiClient = offerApiClient;
            _orderApiClient = orderApiClient;
            _reviewApiClient = reviewApiClient;
            _logger = logger;
        }

 

        //-----парсим строку с фильтрами параметров в список словарей-----
        public  List<Dictionary<string, object>> ParseParamFiltersToDict(string filter)
        {
            var result = new List<Dictionary<string, object>>();
            if (string.IsNullOrWhiteSpace(filter)) return result;
            foreach (var part in filter.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            {
                var kv = part.Split(':', 2, StringSplitOptions.TrimEntries);
                if (int.TryParse(kv[0], out var id))
                {
                    var dict = new Dictionary<string, object> { ["id"] = id };
                    if (kv.Length > 1) dict["value"] = kv[1];
                    result.Add(dict);
                }
            }
            return result;
        }



        //-----вычисление совпадения всех фильтров с параметрами обьявления-----
        public  bool MatchAllFilters(
            List<RentObjParamValueResponse> paramValues,
            List<Dictionary<string, object>> filters)
        {
            var flag = true;
            foreach (var f in filters)
            {
                var filterId = Convert.ToInt32(f["id"]);
                var filterValue = f["value"]?.ToString()?.ToLower();

                if (!paramValues.Any(p =>
                    p.ParamItemId == filterId &&
                    ((p.ValueBool.ToString().ToLower() == filterValue
                    || p.ValueInt.ToString().ToLower() == filterValue
                    || p.ValueString.ToString().ToLower() == filterValue))))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        //-----проверка на конфликт дат обьявления-----
        public async Task<bool> HasDateConflictAsync(int offerId, DateTime start, DateTime end)
        {
            var isExist = await _orderApiClient.HasDateConflict(offerId); //true - есть конфликт, false - нет конфликта
            return isExist;

        }

        //-----отправляем событие в статистику-----
        public async Task SendStatEvent(EntityStatEventRequest request, string type)
        {
            var success = await _statisticClient.AddStatisticToEntityAsync(request);

            if (success)
                Console.WriteLine($"Событие ({type}) успешно добавлено");
            else
                Console.WriteLine($"Ошибка ({type})");
        }



        // =====проверка роли owner + получение userId ==========================


        public async Task<(bool IsOwner, string Error)> ValidateOwnerAsync(int userId, string accessToken)
        {
            var user = await _userApiClient.GetMeAsync(accessToken);

            if (user == null)
                return (false, "Ошибка получения пользователя");


            var userRole = user.RoleName;

            if (!string.Equals(userRole, "owner", StringComparison.OrdinalIgnoreCase))
            {
                return (false, "Вы не собственник имущества");
            }

            return (true, null);
        }


        //-----получение id клиента и статуса заказа по orderId-----

        public async Task<(int userId, string status)> GetClientIdAndStatusFromOrder(int orderId)
        {
            var order = await _orderApiClient.GetOrderByIdAsync(orderId);

           if (order == null)
            {
                throw new Exception("Недействительный orderId ");
                return (-1, "Pending");
            }
            var status = order.Status;
            var userId = order.ClientId;

            return (userId, status);
            
        }

    }
}
