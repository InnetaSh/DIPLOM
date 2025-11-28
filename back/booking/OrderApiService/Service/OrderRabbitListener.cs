using Globals.EventBus;
using Microsoft.Extensions.Logging;

namespace OrderApiService.Services
{
    public class OrderRabbitListener: RabbitMqListenerBase
    {


        private readonly ILogger<OrderRabbitListener> _logger;


        public OrderRabbitListener(ILogger<OrderRabbitListener> logger)
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
