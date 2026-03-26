using OrderApiService.Models;
using OrderContracts;
using OrderContracts.Enum;

namespace OrderApiService.Mappers
{
    public static class OrderMapper
    {
        public static Order MapToModel( OrderRequest request)
        {
            DateTime startDate;
            DateTime endDate;

            if (!DateTime.TryParse(request.StartDate, out startDate))
                throw new ArgumentException($"Неверный формат StartDate: {request.StartDate}");

            if (!DateTime.TryParse(request.EndDate, out endDate))
                throw new ArgumentException($"Неверный формат EndDate: {request.EndDate}");

            return new Order
            {
                OfferId = request.OfferId,
                ClientId = request.ClientId,
                OwnerId = request.OwnerId,
                ClientEmail = request.ClientEmail,
                ClientPhoneNumber = request.ClientPhoneNumber,
                Guests = request.Guests,
                Adults = request.Adults,
                Children = request.Children,
                MainGuestFirstName = request.MainGuestFirstName,
                MainGuestLastName = request.MainGuestLastName,

                StartDate = startDate,
                EndDate = endDate,

                // ===== Финансы =====
                OrderPrice = request.OrderPrice,
                DiscountPercent = request.DiscountPercent,
                DiscountAmount = request.DiscountAmount,
                // DepositAmount = request.DepositAmount,
                TaxAmount = request.TaxAmount,
                TotalPrice = request.TotalPrice,

                // ===== Бесплатная отмена / оплата =====
                // FreeCancelEnabled = request.FreeCancelEnabled,
                //PaidAt = request.PaidAt,

                // ===== Время заезда / выезда =====
                CheckInTime = request.CheckInTime,
                CheckOutTime = request.CheckOutTime,

                // ===== Дополнительно =====
                ClientNote = request.ClientNote,

                // ===== Статус =====
                Status = request.Status == 0
                    ? OrderStatus.Pending
                    : request.Status,

                isBusinessTrip = request.isBusinessTrip,
                PaymentMethod = request.PaymentMethod,

                // PaymentMethod = request.PaymentMethod,

                // ===== Системные поля =====
                CreatedAt = DateTime.UtcNow
            };
        }


        public static OrderResponse MapToResponse( Order model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return new OrderResponse
            {
                // ===== Идентификатор =====
                id = model.id,

                // ===== Основные данные =====
                OfferId = model.OfferId,
                ClientId = model.ClientId,
                OwnerId = model.OwnerId,
                ClientEmail = model.ClientEmail,
                ClientPhoneNumber = model.ClientPhoneNumber,
                Guests = model.Guests,
                Adults = model.Adults,
                Children = model.Children,

                MainGuestFirstName = model.MainGuestFirstName,
                MainGuestLastName = model.MainGuestLastName,
                // ===== Даты проживания =====
                StartDate = model.StartDate,
                EndDate = model.EndDate,

                // ===== Финансы =====
                OrderPrice = model.OrderPrice,
                DiscountPercent = model.DiscountPercent,
                DiscountAmount = model.DiscountAmount,
                // DepositAmount = model.DepositAmount,
                TaxAmount = model.TaxAmount,
                TotalPrice = model.TotalPrice,

                // ===== Бесплатная отмена / оплата =====
                //FreeCancelEnabled = model.FreeCancelEnabled,
                //PaidAt = model.PaidAt,

                // ===== Время заезда / выезда =====
                CheckInTime = model.CheckInTime,
                CheckOutTime = model.CheckOutTime,

                // ===== Примечание =====
                ClientNote = model.ClientNote,

                isBusinessTrip = model.isBusinessTrip,
                // ===== Статус и оплата =====
                Status = model.Status.ToString(),
                PaymentMethod = model.PaymentMethod,

                // ===== Системные поля =====
                CreatedAt = model.CreatedAt
            };
        }

    }
}
