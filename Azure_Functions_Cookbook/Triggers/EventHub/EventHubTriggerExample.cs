using Microsoft.Azure.Functions.Worker;

public class EventHubTriggerExample
{
    // Waiting for the EventHubTrigger to be supported in .NET Isolated Worker
    //[Function("EventHubTriggerExample")]
    public void Run(
        [EventHubTrigger("events")] string[] events)
    {
        foreach (var e in events)
            Console.WriteLine(e);
    }
}