using Globals.Controllers;

namespace OfferApiService.View
{
    public class CreateOfferRequest : IBaseResponse
    {
        public decimal PricePerDay { get; set; }
        public decimal? PricePerWeek { get; set; }
        public decimal? PricePerMonth { get; set; }

        public decimal? DepositPersent { get; set; }
        public string? DepositStatus { get; set; }// статус оплаты(ожидает подтверждения,  подтверждён владельцем и т п )

        public string? PaymentMethod { get; set; }  // Предпочтительный способ оплаты
        public decimal? Tax { get; set; }


        public int MinRentDays { get; set; } = 1;       // Минимальное количество дней аренды
        public bool AllowPets { get; set; }             // Можно ли с животными
        public bool AllowSmoking { get; set; }          // Разрешено ли курение
        public bool AllowChildren { get; set; }         // Можно ли с детьми
        public bool AllowParties { get; set; }          // Разрешены ли вечеринки

        public int MaxGuests { get; set; }              // Максимальное количество гостей



        // ===== Бесплатная отмена бронирования =====

        public bool FreeCancelEnabled { get; set; }       // Доступна ли бесплатная отмена
        public int? FreeCancelUntilHours { get; set; }    // За сколько часов до заезда можно отменить бесплатно
                                                          // Например: 48 → отмена за 48 часов до даты CheckIn


        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }


        public int? OwnerId { get; set; }
        public int RentObjId { get; set; }


    }
}

