using Microsoft.Azure.Functions.Worker;
using Microsoft.DurableTask;

namespace AzureFunctionsCookbook;

public class DurableOrchestrator
{
    [Function(nameof(DurableOrchestrator))]
    public async Task<string> Run(
        [OrchestrationTrigger] TaskOrchestrationContext context)
    {
        var result = await context.CallActivityAsync<string>(
            nameof(DurableActivity),
            "Azure Functions Cookbook");

        return result;
    }
}