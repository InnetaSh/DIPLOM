using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.EventBus
{
    public class RabbitMQMessageBase
    {
        public string Sender { get; private set; }
        public string EventType { get; private set; }
        public string Data { get; set; }  // Само сообщение или данные

        public DateTime TimeSend { get; private set; } = DateTime.UtcNow;

        public RabbitMQMessageBase(string sender, string eventType, string data)
        {
            Sender = sender;
            EventType = eventType;
            Data = data;
        }
    }
}
