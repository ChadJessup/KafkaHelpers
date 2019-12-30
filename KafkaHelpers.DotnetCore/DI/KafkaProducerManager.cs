using System;
using System.Collections.Concurrent;
using KafkaHelpers.Core.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaHelpers.DotnetCore.DI
{
    public class KafkaProducerManager
    {
        private readonly IServiceProvider services;
        private readonly ConcurrentDictionary<Type, object> factories;

        public KafkaProducerManager(IServiceProvider services)
        {
            this.services = services;
        }

        public virtual TProducer Create<TProducer>()
            where TProducer : AbstractProducer
        {
            var factory = services.GetRequiredService<IKafkaProducerFactory<TProducer>>();

            return factory.Create();
        }
    }
}
