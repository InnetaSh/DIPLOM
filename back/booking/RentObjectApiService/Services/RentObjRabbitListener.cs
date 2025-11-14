using Globals.EventBus;
using Microsoft.Extensions.Logging;

namespace UserApiService.Services
{
    public class RentObjRabbitListener: RabbitMqListenerBase
    {


        private readonly ILogger<RentObjRabbitListener> _logger;


        public RentObjRabbitListener(ILogger<RentObjRabbitListener> logger)
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
