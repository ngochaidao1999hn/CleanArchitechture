using CleanArchitechture.Application.Messages.Kafka.Model;

namespace CleanArchitechture.Application.Services.Messages.Kafka
{
    public interface IProducer
    {
        Task<bool> SendMessage<T>(string topicName, T message) where T : IBaseKafkaMessage;
    }
}
