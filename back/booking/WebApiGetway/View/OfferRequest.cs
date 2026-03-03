using Globals.Controllers;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiGetway.View
{
    public class OfferRequest : IBaseResponse
    {
        public int id { get; set; } = -1;

        public string? Title { get; set; }           // Заглавие объявления (переводимое поле)
        public string? Description { get; set; }     // Описание объявления (переводимое поле)
        public string? TitleInfo { get; set; }



        public decimal PricePerDay { get; set; }
        public decimal? PricePerWeek { get; set; }
        public decimal? PricePerMonth { get; set; }

        //public decimal? DepositPersent { get; set; }
        //public string? DepositStatus { get; set; }// статус оплаты(ожидает подтверждения,  подтверждён владельцем и т п )

       // public string? PaymentMethodCode { get; set; }  // Предпочтительный способ оплаты
        public decimal? Tax { get; set; }

        public int MinRentDays { get; set; } = 1;
        public bool AllowPets { get; set; }
        public bool AllowSmoking { get; set; }
        public bool AllowChildren { get; set; }
        public bool AllowParties { get; set; }

        public int MaxGuests { get; set; }


        //// ===== Бесплатная отмена бронирования =====

        //public bool FreeCancelEnabled { get; set; }       // Доступна ли бесплатная отмена
        //public int? FreeCancelUntilHours { get; set; }    // За сколько часов до заезда можно отменить бесплатно
        //                                                  // Например: 48 → отмена за 48 часов до даты CheckIn


        public TimeSpan? CheckInTime { get; set; } = TimeSpan.Parse("11:00:00");
        public TimeSpan? CheckOutTime { get; set; } = TimeSpan.Parse("15:00:00");



        public int? OwnerId { get; set; }
        public RentObjRequest RentObj { get; set; }


    }
}

