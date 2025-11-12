using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Globals.EventBus
{
    public class RabbitMqListenerBase : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private string _queueName;


        public RabbitMqListenerBase(string hostname = "rabbitmq", string queueName = "MyQueue")
        {
            _queueName = queueName;
            var factory = new ConnectionFactory { HostName = hostname };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var msgObj = JsonSerializer.Deserialize<RabbitMQMessageBase>(content);
                HandleMessage(msgObj);
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(_queueName, false, consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }

        public virtual void HandleMessage(RabbitMQMessageBase msgObj)
        {
            
        }
    }
}
