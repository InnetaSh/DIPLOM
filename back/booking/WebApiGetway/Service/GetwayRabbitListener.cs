using Globals.EventBus;

namespace WebApiGateway.Services
{
    public class GetwayRabbitListener: RabbitMqListenerBase
    {
        public override void HandleMessage(RabbitMQMessageBase msgObj)
        {

            if (msgObj.Sender == "GatewayController")
            {
                Console.WriteLine("→ Обработка сообщения от GatewayController");
            }
            else if (msgObj.Sender == "AuthController")
            {
                Console.WriteLine("→ Обработка сообщения от AuthController");
            }
            //base.HandleMessage(message);
        }
    }
}
