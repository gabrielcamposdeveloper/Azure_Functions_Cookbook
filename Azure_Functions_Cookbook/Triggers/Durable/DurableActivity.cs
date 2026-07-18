using Microsoft.Azure.Functions.Worker;

namespace AzureFunctionsCookbook;

public class DurableActivity
{
    [Function(nameof(DurableActivity))]
    public string Run([ActivityTrigger] string input)
    {
        return $"Hello from {input}!";
    }
}