using System;
using Confluent.Kafka;
using KafkaHelpers.Core.Clients;
using KafkaHelpers.Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace KafkaHelpers.DotnetCore.DI
{
    public class KafkaProducerFactory<TProducer> : IKafkaProducerFactory<TProducer>
        where TProducer : AbstractProducer
    {
        private readonly IOptionsMonitor<ProducerConfig> options;

        public KafkaProducerFactory(IOptionsMonitor<ProducerConfig> options)
            => this.options = options;

        public TProducer Create()
        {
            var producerConfig = this.options.Get(typeof(TProducer).Name);

            var producer = (TProducer)Activator.CreateInstance(typeof(TProducer), producerConfig);

            return producer;
        }
    }
}
