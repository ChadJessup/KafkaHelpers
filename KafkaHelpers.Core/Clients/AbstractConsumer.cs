using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Confluent.Kafka;

namespace KafkaHelpers.Core.Clients
{
    public abstract class AbstractConsumer
    {
    }

    public abstract class AbstractConsumer<TKey, TValue> : AbstractConsumer, IConsumer<TKey, TValue>
    {
        private readonly IConsumer<TKey, TValue> consumer;

        public string MemberId => this.consumer?.MemberId ?? "";
        public List<TopicPartition> Assignment => this.consumer.Assignment;
        public List<string> Subscription => this.consumer.Subscription;
        public Handle Handle => this.consumer.Handle;
        public string Name => this.consumer.Name;

        public IConsumerGroupMetadata ConsumerGroupMetadata => consumer.ConsumerGroupMetadata;

        public int AddBrokers(string brokers)
        {
            return this.consumer.AddBrokers(brokers);
        }

        public void Assign(TopicPartition partition)
        {
            this.consumer.Assign(partition);
        }

        public void Assign(TopicPartitionOffset partition)
        {
            this.consumer.Assign(partition);
        }

        public void Assign(IEnumerable<TopicPartitionOffset> partitions)
        {
            this.consumer.Assign(partitions);
        }

        public void Assign(IEnumerable<TopicPartition> partitions)
        {
            this.consumer.Assign(partitions);
        }

        public void Close()
        {
            this.consumer.Close();
        }

        public List<TopicPartitionOffset> Commit()
        {
            return this.consumer.Commit();
        }

        public void Commit(IEnumerable<TopicPartitionOffset> offsets)
        {
            this.consumer.Commit(offsets);
        }

        public void Commit(ConsumeResult<TKey, TValue> result)
        {
            this.consumer.Commit(result);
        }

        public List<TopicPartitionOffset> Committed(IEnumerable<TopicPartition> partitions, TimeSpan timeout)
        {
            return this.consumer.Committed(partitions, timeout);
        }

        public ConsumeResult<TKey, TValue> Consume(CancellationToken cancellationToken = default)
        {
            return this.consumer.Consume(cancellationToken);
        }

        public ConsumeResult<TKey, TValue> Consume(TimeSpan timeout)
        {
            return this.consumer.Consume(timeout);
        }

        public WatermarkOffsets GetWatermarkOffsets(TopicPartition topicPartition)
        {
            return this.consumer.GetWatermarkOffsets(topicPartition);
        }

        public List<TopicPartitionOffset> OffsetsForTimes(IEnumerable<TopicPartitionTimestamp> timestampsToSearch, TimeSpan timeout)
        {
            return this.consumer.OffsetsForTimes(timestampsToSearch, timeout);
        }

        public void Pause(IEnumerable<TopicPartition> partitions)
        {
            this.consumer.Pause(partitions);
        }

        public Offset Position(TopicPartition partition)
        {
            return this.consumer.Position(partition);
        }

        public WatermarkOffsets QueryWatermarkOffsets(TopicPartition topicPartition, TimeSpan timeout)
        {
            return this.consumer.QueryWatermarkOffsets(topicPartition, timeout);
        }

        public void Resume(IEnumerable<TopicPartition> partitions)
        {
            this.consumer.Resume(partitions);
        }

        public void Seek(TopicPartitionOffset tpo)
        {
            this.consumer.Seek(tpo);
        }

        public void StoreOffset(ConsumeResult<TKey, TValue> result)
        {
            this.consumer.StoreOffset(result);
        }

        public void StoreOffset(TopicPartitionOffset offset)
        {
            this.consumer.StoreOffset(offset);
        }

        public void Subscribe(IEnumerable<string> topics)
        {
            this.consumer.Subscribe(topics);
        }

        public void Subscribe(string topic)
        {
            this.consumer.Subscribe(topic);
        }

        public void Unassign()
        {
            this.consumer.Unassign();
        }

        public void Unsubscribe()
        {
            this.consumer.Unsubscribe();
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    this.consumer?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AbstractConsumer()
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

        public ConsumeResult<TKey, TValue> Consume(int millisecondsTimeout)
        {
            return consumer.Consume(millisecondsTimeout);
        }

        public List<TopicPartitionOffset> Committed(TimeSpan timeout)
        {
            return consumer.Committed(timeout);
        }
    }
}
