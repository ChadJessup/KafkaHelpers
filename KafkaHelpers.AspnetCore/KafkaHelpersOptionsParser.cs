using System;
using System.Collections.Generic;
using System.Text;
using KafkaHelpers.Core.Options;
using Microsoft.Extensions.Configuration;

namespace KafkaHelpers.AspnetCore
{
    public class KafkaHelpersOptionsParser
    {
        private readonly IConfiguration configuration;

        public KafkaHelpersOptionsParser(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Parse(KafkaHelpersOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            ParseGlobalSection(options);
            ParseDefaultSection(options);
        }

        private void ParseDefaultSection(KafkaHelpersOptions options)
        {
            var defaults = this.configuration.GetSection($"KafkaHelpers:{nameof(KafkaHelpersOptions.Configs)}:{nameof(KafkaHelpersConfigsOptions.Defaults)}");

            var defaultProducerSection = defaults.GetSection("Producer");

            foreach (var defaultProducerValue in defaultProducerSection.AsEnumerable(makePathsRelative: true))
            {
                options.Configs.Defaults.Producer.Set(defaultProducerValue.Key, defaultProducerValue.Value);
            }

            var defaultConsumerSection = defaults.GetSection("Consumer");

            foreach (var defaultConsumerValue in defaultConsumerSection.AsEnumerable(makePathsRelative: true))
            {
                options.Configs.Defaults.Consumer.Set(defaultConsumerValue.Key, defaultConsumerValue.Value);
            }

            var defaultAdminSection = defaults.GetSection("Admin");

            foreach (var defaultAdminValue in defaultAdminSection.AsEnumerable(makePathsRelative: true))
            {
                options.Configs.Defaults.Admin.Set(defaultAdminValue.Key, defaultAdminValue.Value);
            }
        }

        private void ParseGlobalSection(KafkaHelpersOptions options)
        {
            var globalSection = this.configuration.GetSection($"KafkaHelpers:{nameof(KafkaHelpersOptions.Configs)}:{nameof(KafkaHelpersConfigsOptions.Global)}");

            foreach (var globalValue in globalSection.AsEnumerable(makePathsRelative: true))
            {
                options.Configs.Global.Set(globalValue.Key, globalValue.Value);
            }
        }
    }
}
