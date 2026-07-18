using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask.Client;

namespace AzureFunctionsCookbook;

public class DurableHttpStart
{
    [Function(nameof(DurableHttpStart))]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData request,
        [DurableClient] DurableTaskClient client)
    {
        string instanceId = await client.ScheduleNewOrchestrationInstanceAsync(nameof(DurableOrchestrator));

        return await client.CreateCheckStatusResponseAsync(request, instanceId);
    }
}