using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace AzureFunctionsCookbook;

public class HttpTriggerExample
{
    [Function(nameof(HttpTriggerExample))]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteString("Hello from Azure Functions Cookbook!");
        return response;
    }
}