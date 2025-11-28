using Microsoft.AspNetCore.Mvc;

namespace WebApiGetway.Service.Interfase
{
    public interface IGatewayService
    {
        Task<IActionResult> ForwardRequestAsync<TRequest>(
            string serviceName,
            string route,
            HttpMethod method,
            TRequest? request = null
        ) where TRequest : class;


        Task<IActionResult> ForwardFileAsync(
            string serviceName,
            string route,
            HttpMethod method,
            IFormFile file
        );
    }

}
