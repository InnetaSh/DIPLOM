using Globals.EventBus;
using Microsoft.Extensions.Logging;

namespace LocationApiService.Services
{
    public class LocationRabbitListener : RabbitMqListenerBase
    {
       

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
