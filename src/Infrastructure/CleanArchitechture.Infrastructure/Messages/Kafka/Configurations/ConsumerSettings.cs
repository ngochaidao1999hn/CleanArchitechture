namespace CleanArchitechture.Infrastructure.Messages.Kafka.Configurations
{
    public class ConsumerSettings
    {
        public string BootsrapServer { get; set; }
        public bool AutoCommit { get; set; }
        public string? GroupId { get; set; }
        public string Topic { get; set; }
    }
}
