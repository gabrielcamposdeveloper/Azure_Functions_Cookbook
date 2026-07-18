using Microsoft.Azure.Functions.Worker;

public class ServiceBusTriggerExample
{
    [Function(nameof(ServiceBusTriggerExample))]
    public void Run(
        [ServiceBusTrigger("orders")] string message)
    {
        Console.WriteLine(message);
    }
}