namespace WebApiGetway.Service.Interfase
{
    public interface IUserServiceClient
    {
        Task<HttpResponseMessage> Register(string request);
    }
}
