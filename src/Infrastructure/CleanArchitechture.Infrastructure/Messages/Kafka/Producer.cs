using CleanArchitechture.Application.Messages.Kafka.Model;
using CleanArchitechture.Application.Services.Messages.Kafka;
using CleanArchitechture.Infrastructure.Messages.Kafka.Configurations;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace CleanArchitechture.Infrastructure.Messages.Kafka
{
    public class Producer : IProducer
    {
        private ProducerConfig _config;
        private ProducerSettings _settigns;
        public Producer(IOptions<ProducerSettings> settings)
        {
            _settigns = settings.Value;
            _config = new ProducerConfig() 
            {
                 BootstrapServers = _settigns.BootstrapServer,
                 Acks = Acks.All,
                 Partitioner = Partitioner.ConsistentRandom
            };
        }
        public async Task<bool> SendMessage<T>(string topicName, T message) where T : IBaseKafkaMessage
        {
            using (var producer = new ProducerBuilder<Null, string>(_config).Build())
            {
                var result = await producer.ProduceAsync(topicName, new Message<Null, string> { Value = Newtonsoft.Json.JsonConvert.SerializeObject(message) });
                if (result != null && (result.Status == PersistenceStatus.Persisted || result.Status == PersistenceStatus.PossiblyPersisted))
                { 
                    return true;
                }
                return false;
            }
        }
    }
}
