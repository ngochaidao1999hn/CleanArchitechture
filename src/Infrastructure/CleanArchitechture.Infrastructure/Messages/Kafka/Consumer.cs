using CleanArchitechture.Infrastructure.Messages.Kafka.Configurations;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace CleanArchitechture.Infrastructure.Messages.Kafka
{
    public class Consumer : BackgroundService
    {
        private ConsumerConfig _config;
        private ConsumerSettings _settings;
        public Consumer(IOptions<ConsumerSettings> settings)
        {
            _settings = settings.Value;
            _config = new ConsumerConfig()
            {
                BootstrapServers = _settings.BootsrapServer,
                EnableAutoCommit = _settings.AutoCommit,
                GroupId = "1"
            };
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var consumer = new ConsumerBuilder<Ignore, string>(_config).Build())
            {
                try
                {
                    consumer.Subscribe(_settings.Topic);

                    while (true)
                    {
                        var consumeResult = consumer.Consume();
                        //Handle the message
                        var res = consumeResult.Value;
                        consumer.Commit(consumeResult);
                    }
                }
                catch (ConsumeException ex)
                {
                    consumer.Close();
                }
            }
            return Task.CompletedTask;
        }
    }
}
