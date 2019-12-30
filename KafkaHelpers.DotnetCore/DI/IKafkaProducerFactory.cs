using KafkaHelpers.Core.Clients;

namespace KafkaHelpers.DotnetCore.DI
{
    public interface IKafkaProducerFactory<TProducer>
        where TProducer : AbstractProducer
    {
        TProducer Create();
    }
}
