namespace OrderApiService.Models.Enum
{
    public enum PaymentMethod
    {
        Undefined = 0,      // Не выбран

        OnCheckIn = 1,      // Оплата при заселении (наличными / на месте)

        OnlineCard = 2      // Онлайн-оплата картой (бесконтактное заселение)

    }

}
