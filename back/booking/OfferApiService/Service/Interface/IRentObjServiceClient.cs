namespace OfferApiService.Service.Interface
{
    public interface IRentObjServiceClient
    {
        Task<HttpResponseMessage> GetByCityAsync(string cityTitle);
    }
}
