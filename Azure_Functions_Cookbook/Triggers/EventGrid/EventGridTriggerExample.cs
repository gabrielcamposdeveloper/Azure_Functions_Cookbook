using Azure.Messaging.EventGrid;
using Microsoft.Azure.Functions.Worker;

public class EventGridTriggerExample
{
    [Function("EventGridTriggerExample")]
    public void Run(
        [EventGridTrigger] EventGridEvent eventGridEvent)
    {
        Console.WriteLine(eventGridEvent.EventType);
    }
}