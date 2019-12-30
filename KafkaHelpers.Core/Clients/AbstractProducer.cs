using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace KafkaHelpers.Core.Clients
{
    public class AbstractProducer
    {
    }

    public abstract class AbstractProducer<TKey, TValue> : AbstractProducer, IProducer<TKey, TValue>
    {
        private readonly IProducer<TKey, TValue> producer;

        public Handle Handle => producer.Handle;
        public string Name => producer.Name;

        public int AddBrokers(string brokers)
        {
            return this.producer.AddBrokers(brokers);
        }

        public int Flush(TimeSpan timeout)
        {
            return this.producer.Flush(timeout);
        }

        public void Flush(CancellationToken cancellationToken = default)
        {
            this.producer.Flush(cancellationToken);
        }

        public int Poll(TimeSpan timeout)
        {
            return this.producer.Poll(timeout);
        }

        public void Produce(string topic, Message<TKey, TValue> message, Action<DeliveryReport<TKey, TValue>>? deliveryHandler = null)
        {
            this.producer.Produce(topic, message, deliveryHandler);
        }

        public void Produce(TopicPartition topicPartition, Message<TKey, TValue> message, Action<DeliveryReport<TKey, TValue>>? deliveryHandler = null)
        {
            producer.Produce(topicPartition, message, deliveryHandler);
        }

        public Task<DeliveryResult<TKey, TValue>> ProduceAsync(string topic, Message<TKey, TValue> message)
        {
            return producer.ProduceAsync(topic, message);
        }

        public Task<DeliveryResult<TKey, TValue>> ProduceAsync(TopicPartition topicPartition, Message<TKey, TValue> message)
        {
            return producer.ProduceAsync(topicPartition, message);
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    this.producer?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AbstractProducer()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
