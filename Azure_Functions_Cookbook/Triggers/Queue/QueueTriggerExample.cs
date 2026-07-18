using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionsCookbook;

public class QueueTriggerExample
{
    [Function(nameof(QueueTriggerExample))]
    public void Run([QueueTrigger("orders")] string message)
    {
        Console.WriteLine($"Message received: {message}");
    }
}