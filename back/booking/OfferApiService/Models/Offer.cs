using Globals.Models;
using OfferApiService.Models.Enum;
using OfferApiService.Models.RentObjModel;

namespace OfferApiService.Models
{
    public class Offer : EntityBase
    {
        public Offer()
        {
            CheckInTime = new TimeSpan(15, 0, 0);   // Время заезда по умолчанию (15:00)
            CheckOutTime = new TimeSpan(11, 0, 0);  // Время выезда по умолчанию (11:00)
        }

        // ===== Название и описание объявления =====

        //public string Title { get; set; }           // Заглавие объявления (переводимое поле)
        //public string Description { get; set; }     // Описание объявления (переводимое поле)


        // ===== Базовые цены =====

        public decimal PricePerDay { get; set; }    // Цена за сутки
        public decimal? PricePerWeek { get; set; }  // Цена за неделю (опционально)
        public decimal? PricePerMonth { get; set; } // Цена за месяц (опционально)


        // ===== Депозит =====

        public decimal? DepositPersent { get; set; }    // Процент депозита
        public PaymentType PaymentStatus { get; set; }  // Тип депозита — возвращаемый или нет


        // ===== Налоги =====

        public decimal? Tax { get; set; }               // Налог в процентах от стоимости аренды


        // ===== Правила проживания =====

        public int MinRentDays { get; set; } = 1;       // Минимальное количество дней аренды
        public bool AllowPets { get; set; }             // Можно ли с животными
        public bool AllowSmoking { get; set; }          // Разрешено ли курение
        public bool AllowChildren { get; set; }         // Можно ли с детьми
        public bool AllowParties { get; set; }          // Разрешены ли вечеринки

        public int MaxGuests { get; set; }              // Максимальное количество гостей


        // ===== Дополнительные сборы =====

        public decimal? CleaningFee { get; set; }       // Стоимость уборки
        public decimal? AdditionalGuestFee { get; set; } // Доплата за гостя сверх лимита


        // ===== Бесплатная отмена бронирования =====

        public bool FreeCancelEnabled { get; set; }       // Доступна ли бесплатная отмена
        public int? FreeCancelUntilHours { get; set; }    // За сколько часов до заезда можно отменить бесплатно
                                                          // Например: 48 → отмена за 48 часов до даты CheckIn


        // ===== Отношения =====

        public int OwnerId { get; set; }                // ID владельца объявления

        public int RentObjId { get; set; }              // ID объекта недвижимости
        public RentObject RentObj { get; set; } // Связь с объектом недвижимости


        // ===== Время заезда / выезда =====

        public TimeSpan? CheckInTime { get; set; }       // Время заезда
        public TimeSpan? CheckOutTime { get; set; }      // Время выезда


        // ===== Забронированные даты =====

        public List<BookedDate> BookedDates { get; set; } = new List<BookedDate>();  // Список бронирований
    }
}
