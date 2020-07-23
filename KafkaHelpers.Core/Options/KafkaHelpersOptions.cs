using System;
using System.Collections.Generic;
using Confluent.Kafka;
using KafkaHelpers.Core.Clients;

namespace KafkaHelpers.Core.Options
{
    public class KafkaHelpersOptions
    {
        public KafkaHelpersConfigsOptions Configs { get; set; } = new KafkaHelpersConfigsOptions();

        public static void CopyValues(IEnumerable<KeyValuePair<string, string>> source, Config destination)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination is null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            foreach (var kvp in source)
            {
                destination.Set(kvp.Key, kvp.Value);
            }
        }

        public static void PopulateProducerConfigs<TProducer>(ProducerConfig producerConfig, KafkaHelpersOptions options)
            where TProducer : AbstractProducer
        {
            if (producerConfig is null)
            {
                throw new ArgumentNullException(nameof(producerConfig));
            }

            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            // Global values... KafkaHelpers:Configs:Global
            KafkaHelpersOptions.CopyValues(source: options.Configs.Global, destination: producerConfig);

            // Default Producer values... KafkaHelpers:Configs:Defaults:Producer
            KafkaHelpersOptions.CopyValues(source: options.Configs.Defaults.Producer, destination: producerConfig);

            // TProducer Name values... KafkaHelpers:Configs:Producers:TProducer.Name
        }
    }
}
