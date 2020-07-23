using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using KafkaHelpers.Core.Clients;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using KafkaHelpers.DotnetCore.DI;
using KafkaHelpers.Core.Options;
using Microsoft.Extensions.Configuration;
using KafkaHelpers.AspnetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddKafkaHelpers(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<KafkaHelpersOptionsParser>();

            services.AddOptions<KafkaHelpersOptions>()
                .Configure<IConfiguration, KafkaHelpersOptionsParser>((kho, config, khop) =>
                {
                    khop.Parse(kho);
                });

            services.TryAddTransient(typeof(IKafkaProducerFactory<>), typeof(KafkaProducerFactory<>));
            services.TryAddSingleton<KafkaProducerManager>();

            return services;
        }

        public static IServiceCollection AddKafkaProducer<TProducer, TConfiguration>(this IServiceCollection services)
            where TProducer : AbstractProducer
            where TConfiguration : ProducerConfig
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddKafkaHelpers();

            services.AddOptions<TConfiguration>(typeof(TProducer).Name)
                .Configure<IOptions<KafkaHelpersOptions>>((producerConfig, options) =>
                {
                    KafkaHelpersOptions.PopulateProducerConfigs<TProducer>(producerConfig, options.Value);
                });

            services.TryAddSingleton(sp =>
            {
                var manager = sp.GetRequiredService<KafkaProducerManager>();

                return manager.Create<TProducer>();
            });

            return services;
        }

        public static IServiceCollection AddKafkaProducer<TProducer>(this IServiceCollection services)
            where TProducer : AbstractProducer
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddKafkaHelpers();

            services.AddOptions<ProducerConfig>(typeof(TProducer).Name)
                .Configure<IOptions<KafkaHelpersOptions>>((producerConfig, options) =>
                {
                    KafkaHelpersOptions.PopulateProducerConfigs<TProducer>(producerConfig, options.Value);
                });

            services.TryAddSingleton(sp =>
            {
                var manager = sp.GetRequiredService<KafkaProducerManager>();

                return manager.Create<TProducer>();
            });

            return services;
        }

        public static IServiceCollection AddKafkaConsumer<TConsumer>(this IServiceCollection services)
            where TConsumer : AbstractConsumer
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions();

            services.TryAddSingleton<TConsumer>();

            return services;
        }

        public static IServiceCollection AddKafkaAdminClient<TAdminClient>(this IServiceCollection services)
            where TAdminClient : AbstractAdminClient
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions();

            services.TryAddSingleton<TAdminClient>();

            return services;
        }

        public static IServiceCollection AddKafkaConfiguration<TKafkaConfig>(this IServiceCollection services)
            where TKafkaConfig : ClientConfig
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions<TKafkaConfig>();
            services.AddSingleton<TKafkaConfig>();

            return services;
        }
    }
}
