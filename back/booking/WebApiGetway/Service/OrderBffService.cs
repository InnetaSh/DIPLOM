
using Microsoft.AspNetCore.Mvc;
using OfferContracts;
using OfferContracts.RentObj;
using OrderContracts;
using ReviewContracts;
using StatisticContracts;
using System.Text.Json;
using System.Text.Json.Serialization;
using TranslationContracts;
using UserContracts;
using WebApiGetway.Clients.Interface;
using WebApiGetway.Helpers;
using WebApiGetway.Service.Interfase;


namespace WebApiGetway.Service
{
    public class OrderBffService : IOrderBffService
    {
        private readonly ITranslationApiClient _translationClient;
        private readonly ILocationApiClient _locationClient;
        private readonly IStatisticApiClient _statisticClient;
        private readonly IOfferApiClient _offerApiClient;
        private readonly IUserApiClient _userApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly IReviewApiClient _reviewApiClient;
        private readonly ILogger<OfferBffService> _logger;
        private readonly HelpersFunctions _helpers;
        public OrderBffService
                (ITranslationApiClient translationClient,
                ILocationApiClient locationClient,
                IStatisticApiClient statisticClient,
                IUserApiClient userApiClient,
                IOfferApiClient offerApiClient,
                IOrderApiClient orderApiClient,
                IReviewApiClient reviewApiClient,
                ILogger<OfferBffService> logger,
                HelpersFunctions helpers)
        {
            _translationClient = translationClient;
            _locationClient = locationClient;
            _statisticClient = statisticClient;
            _userApiClient = userApiClient;
            _offerApiClient = offerApiClient;
            _orderApiClient = orderApiClient;
            _reviewApiClient = reviewApiClient;
            _logger = logger;
            _helpers = helpers;
        }



        //============================================================================================
        //      CREATING AN ORDER
        //============================================================================================
        /// <summary>
        /// Создаёт заказ на основе выбранного оффера, пользователя и параметров бронирования.
        /// Выполняет расчёт стоимости, сохраняет заказ, связывает его с пользователем и оффером,
        /// а также отправляет события статистики и обновляет скидку пользователя.
        /// </summary>
        /// <param name="request">Данные для создания заказа</param>
        /// <param name="lang">Язык для получения переводов</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Идентификатор созданного заказа</returns>
        /// <exception cref="ArgumentNullException">Если request == null</exception>
        /// <exception cref="Exception">Если заказ не был создан или не привязался</exception>
        public async Task<int> CreateOrder(
              CreateOrderRequest request,
              int userId,
              decimal userDiscountPercent,
              string lang,
               string accessToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.OfferId <= 0)
                throw new ArgumentException("Invalid OfferId");

            if (userId <= 0)
                _logger.LogWarning("CreateOrder called with userId = 0");

            
            var user = await _userApiClient.GetMeAsync(accessToken);

            var ClientPhoneNumber = user?.PhoneNumber ?? null;
            var ClientEmail = user?.Email ?? null;

           
            var offer = await _offerApiClient.GetFullOfferById(
                request.OfferId,
                request.StartDate.ToString(),
                request.EndDate.ToString(),
                request.Adults,
                request.Children,
                request.Rooms,
                userDiscountPercent);

            if (offer == null)
            {
                _logger.LogWarning("Offer not found. OfferId={OfferId}", request.OfferId);
                return -1;
            }

            var rentObj = offer.RentObj;

            if (rentObj == null)
                throw new Exception("Offer.RentObj is null");

            var mainImg = rentObj.Images?.FirstOrDefault()?.Url ?? string.Empty;
            var countryId = rentObj.CountryId ;
            var cityId = rentObj.CityId;

           
            var translationsOfferTask = _translationClient.GetOfferTranslationByIdAsync(request.OfferId, lang);
            var translationsCountryTask = _translationClient.GetCountryTranslationByIdAsync(countryId, lang);
            var translationsCityTask = _translationClient.GetCityTranslationByIdAsync(cityId, lang);

            await Task.WhenAll(
                translationsOfferTask,
                translationsCountryTask,
                translationsCityTask
            );
            var offerTranslation = translationsOfferTask.Result ?? new TranslationResponse();
            var countryTranslation = translationsCountryTask.Result ?? new TranslationResponse();
            var cityTranslation = translationsCityTask.Result ?? new TranslationResponse();


            var orderRequest = new OrderRequest
            {
                OfferId = request.OfferId,
                ClientId = userId,
                OwnerId = request.OwnerId,
                ClientEmail = ClientEmail,
                ClientPhoneNumber = ClientPhoneNumber,

                Adults = request.Adults,
                Children = request.Children,

                MainGuestFirstName = request.MainGuestFirstName,
                MainGuestLastName = request.MainGuestLastName,


                StartDate = request.StartDate,
                EndDate = request.EndDate,
                isBusinessTrip = request.isBusinessTrip,
                PaymentMethod = request.PaymentMethod,

                OrderPrice = offer.OrderPrice ?? 0,
                DiscountPercent = offer.DiscountPercent ?? 0,
                DiscountAmount = offer.DiscountAmount ?? 0,
                TotalPrice = offer.TotalPrice ?? 0,

                CheckInTime = offer.CheckInTime ?? TimeSpan.Zero,
                CheckOutTime = offer.CheckOutTime ?? TimeSpan.Zero,

                ClientNote = request.ClientNote,
                Status = 0,
            };
            var orderId = await _orderApiClient.CreateOrder(orderRequest);
            if (orderId <= 0)
            {
                _logger.LogError("Order creation failed. OfferId={OfferId}", request.OfferId);
                throw new Exception("Order was not created");
            }

            _logger.LogInformation("Order created. OrderId={OrderId}", orderId);
           
            var addToOfferTask = _offerApiClient.AddOrderToOffersOrderList(request.OfferId, orderId);
            var addToUserTask = _userApiClient.AddOrderToUsersOrderList(orderId, accessToken);

            await Task.WhenAll(addToOfferTask, addToUserTask);

            if (!addToOfferTask.Result)
            {
                _logger.LogError("Failed to link order to offer. OrderId={OrderId}", orderId);
                throw new Exception("Order not linked to offer");
            }

            if (!addToUserTask.Result)
            {
                _logger.LogError("Failed to link order to user. OrderId={OrderId}", orderId);
                throw new Exception("Order not linked to user");
            }

            var entityStatEventRequest = new EntityStatEventRequest
            {
                EntityId = request.OfferId,
                EntityType = "Offer",
                ActionType = "Booking",
                UserId = userId
            };

            var entityStatCityEventRequest = new EntityStatEventRequest
            {
                EntityId = cityId,
                EntityType = "City",
                ActionType = "Booking",
                UserId = userId
            };

            decimal discountCount = 0.25m;

            var statOfferTask = _helpers.SendStatEvent(entityStatEventRequest, "Offer");
            var statCityTask = _helpers.SendStatEvent(entityStatCityEventRequest, "City");
            var discountTask = _userApiClient.UpdateDiscount(userId, discountCount);

            _ = Task.Run(async () =>
            {
                try
                {
                    await Task.WhenAll(statOfferTask, statCityTask, discountTask);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка в побочных задачах");
                }
            });

            return orderId;
        }


        //===============================================================================================================
        //          EDIT ORDER STATUS
        //======================================+=========================================================================
        /// <summary>
        /// Обновляет статус заказа. Проверяет, что пользователь является владельцем оффера.
        /// </summary>
        /// <param name="orderId">Идентификатор заказа</param>
        /// <param name="orderState">Новый статус заказа</param>
        /// <returns>true если успешно обновлено</returns>
        /// <exception cref="ArgumentException">Некорректные входные данные</exception>
        /// <exception cref="Exception">Если заказ не найден или нет прав</exception>
        public async Task<bool> UpdateStateOrder(
            int orderId,
            string orderState)
        {
            if (orderId <= 0)
                throw new ArgumentException("Invalid orderId");

            var order = await _orderApiClient.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                _logger.LogWarning("Order not found. OrderId={OrderId}", orderId);
                throw new Exception("Order not found");
            }

            var offerId = order.OfferId;

            var isOwner = await _userApiClient.ValidOffer(offerId);

            if (!isOwner)
            {
                _logger.LogWarning(
                    "User is not owner of offer. OfferId={OfferId}, OrderId={OrderId}",
                    offerId,
                    orderId);

                throw new Exception("User is not owner of the offer");
            }

            var isUpdated = await _orderApiClient.UpdateStateOrder(offerId, orderState);
            if (!isUpdated)
            {
                _logger.LogError(
                    "Failed to update order status. OrderId={OrderId}, State={State}",
                    orderId,
                    orderState);
            }

            return isUpdated;
        }

        //===============================================================================================================
        // GET ALL orders BY offerId
        //===============================================================================================================
        /// <summary>
        /// Получает все заказы по offerId и обновляет их статус (если просрочены).
        /// </summary>
        public async Task<IEnumerable<OrderResponse>> GetOrdersByOfferId(
           int offerId,
           string lang)
        {
            if (offerId <= 0)
                throw new ArgumentException("Invalid offerId");

            var orders = await _orderApiClient.GetOrdersByOfferId(offerId);
            if (orders == null)
            {
                _logger.LogWarning("Orders not found. OfferId={OfferId}", offerId);
                return Enumerable.Empty<OrderResponse>();
            }
            var ordersList = orders.ToList();

            if (!ordersList.Any())
                return ordersList;

            var orderState = "Completed";

            var semaphore = new SemaphoreSlim(10);
            var updateTasks = ordersList
                 .Where(order =>
                     order.EndDate != default &&
                     order.EndDate.ToUniversalTime() < DateTime.UtcNow &&
                     order.Status != orderState)
                 .Select(async order =>
                 {
                     await semaphore.WaitAsync();
                     try
                     {
                         var updated = await _orderApiClient.UpdateStateOrder(order.id, orderState);

                         if (!updated)
                         {
                             _logger.LogWarning(
                                 "Failed to update order status. OrderId={OrderId}",
                                 order.id);
                         }
                     }
                     finally
                     {
                         semaphore.Release();
                     }
                 });

            await Task.WhenAll(updateTasks);

            return orders;
        }


        // =====================================================================
        //  GET ALL orders  BY userId
        // =====================================================================
        /// <summary>
        /// Получает заказы пользователя и формирует карточки.
        /// Также обновляет статус заказов (если просрочены).
        /// </summary>
        public async Task<IEnumerable<OrderResponseForUserCard>> GetOrdersByUserId(int userId, string lang)
        {
            if (userId <= 0)
                throw new ArgumentException("Invalid userId");


            var orders = await _orderApiClient.GetOrdersByUserIdAsync(userId);
            if (orders == null)
            {
                _logger.LogWarning("Orders not found for user. UserId={UserId}", userId);
                return Enumerable.Empty<OrderResponseForUserCard>();
            }

            var ordersList = orders.ToList();

            if (!ordersList.Any())
                return Enumerable.Empty<OrderResponseForUserCard>();

            var orderState = "Completed";
            var updateTasks = orders
               .Where(order =>
                   order.EndDate != default &&
                   order.EndDate.ToUniversalTime() < DateTime.UtcNow &&
                   order.Status != orderState)
               .Select(async order =>
               {
                   var updated = await _orderApiClient.UpdateStateOrder(order.id, orderState);

                   if (!updated)
                   {
                       _logger.LogWarning(
                           "Failed to update order status. OrderId={OrderId}",
                           order.id);
                   }
                   else
                   {
                       order.Status = orderState;
                   }
               });

            await Task.WhenAll(updateTasks);

            var semaphore = new SemaphoreSlim(10);
            var tasks = orders.Select(async order =>
            {
                await semaphore.WaitAsync();
                try
                {
                    var idOrder = order.id;
                    var idOffer = order.OfferId;

                    var offer = await _offerApiClient.GetOfferById(idOffer);

                    if (offer == null)
                    {
                        _logger.LogWarning(
                            "Offer not found. OfferId={OfferId}, OrderId={OrderId}",
                            idOffer,
                            idOrder);

                        return null; 
                    }

                    var mainImgUrl = offer.RentObj?.Images?.FirstOrDefault()?.Url ?? "";
                    var cityId = offer.RentObj?.CityId ?? 0;

                    var offerTranslateTask = _translationClient.GetOfferTranslationByIdAsync(idOffer, lang);
                    var cityTranslateTask = _translationClient.GetCityTranslationByIdAsync(cityId, lang);

                    await Task.WhenAll(offerTranslateTask, cityTranslateTask);

                    var offerTranslate = offerTranslateTask.Result;
                    var cityTranslate = cityTranslateTask.Result;

                    return new OrderResponseForUserCard
                    {
                        OrderId = idOrder,
                        OfferId = idOffer,
                        ClientId = userId,
                        CityId = cityId,
                        CityTitle = cityTranslate.Title ?? "N/A",
                        Title = offerTranslate.Title ?? "N/A",
                        StartDate = order.StartDate.ToString(),
                        EndDate = order.EndDate.ToString(),
                        TotalPrice = order.TotalPrice,
                        PaymentMethod = order.PaymentMethod,
                        Status = order.Status,
                        MainImageUrl = mainImgUrl
                    };
                }
                finally
                {
                    semaphore.Release();
                }
            });

            var result = await Task.WhenAll(tasks);

            return result.Where(x => x != null)!;
        }
    }
}
