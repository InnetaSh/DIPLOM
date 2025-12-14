namespace OrderApiService.View
{
    public class AdditionalParamsRequest
    {
        public decimal BasePrice { get; set; }
        public decimal Tax { get; set; }
        public int DepositPercent { get; set; }
        public int PaitAtCountDay { get; set; }
        public decimal UserDiscountPercent { get; set; }
    }
}
