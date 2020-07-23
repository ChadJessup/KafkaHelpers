using Confluent.Kafka;

namespace KafkaHelpers.Core.Options
{
    public class KafkaHelpersConfigsOptions
    {
        public ClientConfig Global { get; set; } = new ClientConfig();
        public DefaultClientConfigs Defaults { get; set; } = new DefaultClientConfigs();
    }
}
