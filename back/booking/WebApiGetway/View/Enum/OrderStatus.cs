namespace WebApiGetway.Enum
{
    public enum OrderStatus
    {
        Pending = 0,       // ожидает подтверждения
        Confirmed = 1,     // подтверждён владельцем
        Paid = 2,          // оплачен
        Cancelled = 3,     // отменён пользователем
        Rejected = 4,      // отклонён владельцем
        Completed = 5      // аренда завершена
    }

}
