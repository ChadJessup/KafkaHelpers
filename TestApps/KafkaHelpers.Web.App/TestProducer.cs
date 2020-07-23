using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using KafkaHelpers.AspnetCore;
using KafkaHelpers.Core.Clients;

namespace KafkaHelpers.Web.App
{
    public class TestProducer2 : AbstractProducer<string, string>
    {
        public TestProducer2(ProducerConfig config)
            : base(new ProducerBuilder<string, string>(config))
        {
        }
    }

    public class TestProducer : AbstractProducer<string, string>
    {
        public TestProducer(ProducerConfig config)
            : base(new ProducerBuilder<string, string>(config))
        {
        }
    }
}
