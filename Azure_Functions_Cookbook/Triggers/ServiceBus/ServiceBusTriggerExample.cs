using Microsoft.Azure.Functions.Worker;

public class ServiceBusTriggerExample
{
    // Waiting for the ServiceBusTrigger to be supported in .NET Isolated Worker
    //[Function(nameof(ServiceBusTriggerExample))]
    public void Run(
        [ServiceBusTrigger("orders")] string message)
    {
        Console.WriteLine(message);
    }
}