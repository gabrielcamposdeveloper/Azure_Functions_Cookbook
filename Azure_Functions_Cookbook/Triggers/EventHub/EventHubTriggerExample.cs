using Microsoft.Azure.Functions.Worker;

public class EventHubTriggerExample
{
    [Function("EventHubTriggerExample")]
    public void Run(
        [EventHubTrigger("events")] string[] events)
    {
        foreach (var e in events)
            Console.WriteLine(e);
    }
}