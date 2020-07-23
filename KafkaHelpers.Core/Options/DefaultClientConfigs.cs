using Confluent.Kafka;

namespace KafkaHelpers.Core.Options
{
    public class DefaultClientConfigs
    {
        public ProducerConfig Producer { get; set; } = new ProducerConfig();
        public ConsumerConfig Consumer { get; set; } = new ConsumerConfig();
        public AdminClientConfig Admin { get; set; } = new AdminClientConfig();
    }
}
