using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KafkaHelpers.AspnetCore;
using KafkaHelpers.Core.Clients;

namespace KafkaHelpers.Web.App
{
    public class TestProducer : AbstractProducer<string, string>
    {
        private readonly StandardProducerConfig config;

        public TestProducer(StandardProducerConfig config)
        {
            this.config = config;
        }
    }
}
