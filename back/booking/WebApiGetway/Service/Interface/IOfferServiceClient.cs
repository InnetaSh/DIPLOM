namespace WebApiGetway.Service.Interfase
{
    public interface IOfferServiceClient
    {
        Task<HttpResponseMessage> GetByCityAsync(string cityTitle);
    }
}
