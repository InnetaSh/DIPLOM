using Globals.EventBus;
using Microsoft.Extensions.Logging;


namespace AttractionApiService.Service
{
    public class AttractionRabbitListener: RabbitMqListenerBase
    {


        private readonly ILogger<AttractionRabbitListener> _logger;


        public AttractionRabbitListener(ILogger<AttractionRabbitListener> logger)
        {
            _logger = logger;

        }
        
        public override void HandleMessage(RabbitMQMessageBase msgObj)
        {
            if (msgObj.Sender == "GatewayController")
    {
                _logger.LogInformation("→ Обработка сообщения от GatewayController");
    }
    else if (msgObj.Sender == "AuthController")
    {
                _logger.LogInformation("→ Обработка сообщения от AuthController");
    }
            //base.HandleMessage(message);
        }
    }
}
