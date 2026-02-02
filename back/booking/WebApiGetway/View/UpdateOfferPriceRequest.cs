namespace WebApiGetway.View
{
    public class UpdateOfferPriceRequest
    {
        public int id { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal? PricePerWeek { get; set; }
        public decimal? PricePerMonth { get; set; }

        public decimal? DepositPersent { get; set; }
        public string? DepositStatus { get; set; }// статус оплаты(ожидает подтверждения,  подтверждён владельцем и т п )

        public string? PaymentMethod { get; set; }  // Предпочтительный способ оплаты
        public decimal? Tax { get; set; }

        public decimal? CleaningFee { get; set; }       // Стоимость уборки
        public decimal? AdditionalGuestFee { get; set; } // Доплата за гостя сверх лимита


        // ===== Бесплатная отмена бронирования =====

        public bool FreeCancelEnabled { get; set; }       // Доступна ли бесплатная отмена
        public int? FreeCancelUntilHours { get; set; }    // За сколько часов до заезда можно отменить бесплатно
                                                          // Например: 48 → отмена за 48 часов до даты CheckIn
    }
}
