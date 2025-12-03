using Globals.EventBus;
using Microsoft.Extensions.Logging;

namespace OfferApiService.Services
{
    public class LocationRabbitListener : RabbitMqListenerBase
    {
        //private readonly ILogger<OfferRabbitListener> _logger;


        //public OfferRabbitListener(ILogger<OfferRabbitListener> logger)
        //{
        //    _logger = logger;

        //}

        public override void HandleMessage(RabbitMQMessageBase msgObj)
        {
            //if (msgObj.Sender == "GatewayController")
            //{
            //    _logger.LogInformation("→ Обработка сообщения от GatewayController");
            //}
            //else if (msgObj.Sender == "AuthController")
            //{
            //    _logger.LogInformation("→ Обработка сообщения от AuthController");
            //}
            //base.HandleMessage(message);
        }
    }
}
