namespace WebApiGetway.Service.Interfase
{
    public interface IUserServiceClient
    {
        Task<HttpResponseMessage> Login(object request);
    }
}
