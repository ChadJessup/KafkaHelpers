# KafkaHelpers

Miscellaneous helpers for using the official Kafka C# library ([confluent-kafka-dotnet](https://github.com/confluentinc/confluent-kafka-dotnet)) with common dotnet/aspnet core patterns.

Since these helpers heavily rely on the official C# library, there might be a slight delay on updating to new versions.
Thankfully Confluent is very conscientious of breaking APIs, delays will hopefully be minimal.

## Libraries

* TODO: ```KafkaHelpers.Core```: Contains all of the raw components to be used in a piecemeal fashion. This can be used alone to allow for more custom/advanced scenarios.

* TODO: ```KafkaHelpers.DotnetCore```: Contains code that layers in dotnet core specific patterns (e.g., eventing, logging, DI, etc). This can be used for non-aspnet core specific scenarios.

* TODO: ```KafkaHelpers.AspnetCore```: Contains a further layer to specifically integrate with the standard patterns of aspnet core.

* TODO: ```KafkaHelpers.Tools.*```: These apps contain dotnet cli tooling, that should allow for troubleshooting Kafka Clusters and Clients, enable CI/CD scenarios, etc, from a command line.

* TODO: ```KafkaHelpers.Tests.*```: Tests, and test helpers. These would be a good place to start when figuring out how to use the helpers if the documentation isn't enough.
  * TODO: ```KafkaHelpers.Tests.Helpers```: This library can be independently consumed to help with writing unit tests in other projects.

### Potential Features/Libraries

* AspnetCore HealthCheck for Kafka Cluster and/or topic lag

## Dependency Injection

Due to the builder pattern used to instantiate Kafka Clients, there can be difficulties injecting Kafka clients into dependent classes.

The ```KafkaHelpers.Core.Clients``` namespace contains client wrapping classes which can be derived from, to allow dependency injection using the standard ```Microsoft.Extensions.DependencyInjection``` mechanisms. Essentially, typed clients.
Other DI containers should be allowable as well, but that is left up to the reader.

### Usage

* TODO

## Logging

While it is possible to provide a log handler to Kafka clients when they're being built, integrating these messages to the ```Microsoft.Extensions.Logging``` abstraction layer is left up to the user.

### Logging Usage

* TODO

## Configuration

Standard Kafka client configuration is via a collection of key:value pairs, and integrating with the ```Microsoft.Extensions.Configuration``` system is non-trivial.

### Configuration Usage

* TODO

## Metrics

Events

### Metrics Usage

* TODO

## Testing

Mock broker in librdkafka

### Testing Usage

* TODO
