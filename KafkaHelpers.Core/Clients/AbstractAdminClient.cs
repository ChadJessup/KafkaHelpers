using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace KafkaHelpers.Core.Clients
{
    public abstract class AbstractAdminClient : IAdminClient
    {
        private readonly IAdminClient adminClient;

        public Handle Handle => this.adminClient.Handle;
        public string Name => this.adminClient.Name;

        public int AddBrokers(string brokers)
        {
            return this.adminClient.AddBrokers(brokers);
        }

        public Task AlterConfigsAsync(Dictionary<ConfigResource, List<ConfigEntry>> configs, AlterConfigsOptions? options = null)
        {
            return this.adminClient.AlterConfigsAsync(configs, options);
        }

        public Task CreatePartitionsAsync(IEnumerable<PartitionsSpecification> partitionsSpecifications, CreatePartitionsOptions? options = null)
        {
            return this.adminClient.CreatePartitionsAsync(partitionsSpecifications, options);
        }

        public Task CreateTopicsAsync(IEnumerable<TopicSpecification> topics, CreateTopicsOptions? options = null)
        {
            return this.adminClient.CreateTopicsAsync(topics, options);
        }

        public Task DeleteTopicsAsync(IEnumerable<string> topics, DeleteTopicsOptions? options = null)
        {
            return this.adminClient.DeleteTopicsAsync(topics, options);
        }

        public Task<List<DescribeConfigsResult>> DescribeConfigsAsync(IEnumerable<ConfigResource> resources, DescribeConfigsOptions? options = null)
        {
            return this.adminClient.DescribeConfigsAsync(resources, options);
        }

        public Metadata GetMetadata(string topic, TimeSpan timeout)
        {
            return this.adminClient.GetMetadata(topic, timeout);
        }

        public Metadata GetMetadata(TimeSpan timeout)
        {
            return this.adminClient.GetMetadata(timeout);
        }

        public GroupInfo ListGroup(string group, TimeSpan timeout)
        {
            return this.adminClient.ListGroup(group, timeout);
        }

        public List<GroupInfo> ListGroups(TimeSpan timeout)
        {
            return this.adminClient.ListGroups(timeout);
        }

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AbstractAdminClient()
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
