using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionsCookbook;

public class KafkaTriggerExample
{
    // Waiting for the KafkaTrigger to be supported in .NET Isolated Worker
    //[Function(nameof(KafkaTriggerExample))]
    public void Run([KafkaTrigger(brokerList: "localhost:9092", topic: "orders", ConsumerGroup = "$Default")] string[] events)
    {
        foreach (var message in events)
        {
            Console.WriteLine($"Kafka message: {message}");
        }
    }
}