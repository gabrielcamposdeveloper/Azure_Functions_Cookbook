using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionsCookbook;

public class TimerTriggerExample
{
    [Function(nameof(TimerTriggerExample))]
    public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo timer)
    {
        Console.WriteLine($"[Azure Functions Cookbook] Timer Trigger executed at {DateTime.UtcNow:O} UTC.");
    }
}