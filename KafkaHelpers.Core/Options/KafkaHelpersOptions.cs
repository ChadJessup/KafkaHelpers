using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Confluent.Kafka;

namespace KafkaHelpers.Core.Options
{
    public class KafkaHelpersOptions
    {
        public KafkaHelpersConfigsOptions Configs { get; set; } = new KafkaHelpersConfigsOptions();

        public static void CopyValues(IEnumerable<KeyValuePair<string, string>> source, Config destination)
        {
            source = source ?? throw new ArgumentNullException(nameof(source));
            destination = destination ?? throw new ArgumentNullException(nameof(destination));

            foreach (var kvp in source)
            {
                destination.Set(kvp.Key, kvp.Value);
            }
        }
    }
}
