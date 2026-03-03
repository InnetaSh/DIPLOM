using Globals.Controllers;
using OfferApiService.Models;
using OfferApiService.Models.Enum;
using OfferApiService.View.RentObj;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OfferApiService.View
{
    public class OfferRequest : IBaseRequest
    {
        public int id { get; set; }

        public string? Title { get; set; }           // Заглавие объявления (переводимое поле)

        public string? Description { get; set; }     // Описание объявления (переводимое поле)
        public string? TitleInfo { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal? PricePerWeek { get; set; }
        public decimal? PricePerMonth { get; set; }

        //public decimal? DepositPersent { get; set; }
        //public string DepositStatus { get; set; }// статус оплаты(ожидает подтверждения,  подтверждён владельцем и т п )

        //public string PaymentMethodCode { get; set; }  // Предпочтительный способ оплаты
        public decimal? Tax { get; set; }

        public int MinRentDays { get; set; } = 1;       // Минимальное количество дней аренды
        public bool AllowPets { get; set; }             // Можно ли с животными
        public bool AllowSmoking { get; set; }          // Разрешено ли курение
        public bool AllowChildren { get; set; }         // Можно ли с детьми
        public bool AllowParties { get; set; }          // Разрешены ли вечеринки

        public int MaxGuests { get; set; }              // Максимальное количество гостей


     
        //// ===== Бесплатная отмена бронирования =====

        //public bool FreeCancelEnabled { get; set; }       // Доступна ли бесплатная отмена
        //public int? FreeCancelUntilHours { get; set; }    // За сколько часов до заезда можно отменить бесплатно
        //                                                  // Например: 48 → отмена за 48 часов до даты CheckIn


        public TimeSpan? CheckInTime { get; set; } = TimeSpan.Parse("11:00:00");
        public TimeSpan? CheckOutTime { get; set; } = TimeSpan.Parse("15:00:00");

        public int OwnerId { get; set; }
        public RentObjRequest RentObj { get; set; }


        public static Offer MapToModel(OfferRequest request, string baseUrl)
        {

            return new Offer
            {
                id = request.id,

                PricePerDay = request.PricePerDay,
                PricePerWeek = request.PricePerWeek,
                PricePerMonth = request.PricePerMonth,

                //DepositPersent = request.DepositPersent,
                //DepositStatus = depositStatus,
                Tax = request.Tax,

                MinRentDays = request.MinRentDays,
                AllowPets = request.AllowPets,
                AllowSmoking = request.AllowSmoking,
                AllowChildren = request.AllowChildren,
                AllowParties = request.AllowParties,

                MaxGuests = request.MaxGuests,
             
                //FreeCancelEnabled = request.FreeCancelEnabled,
                //FreeCancelUntilHours = request.FreeCancelUntilHours,

                //PaymentMethod = paymentMethod,

                CheckInTime = request.CheckInTime,
                CheckOutTime = request.CheckOutTime,

                OwnerId = request.OwnerId,
                RentObj = request.RentObj != null
                    ? RentObjRequest.MapToModel(request.RentObj)
                    : null,

            };
        }
    }
}
