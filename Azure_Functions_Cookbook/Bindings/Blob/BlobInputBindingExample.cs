using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;

namespace AzureFunctionsCookbook.Bindings.Blob;

public class BlobInputBindingExample
{
    [Function(nameof(BlobInputBindingExample))]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "blob-input/{fileName}")] HttpRequestData request,
        [BlobInput("documents/{fileName}")] string? fileContent)
    {
        var response = request.CreateResponse(HttpStatusCode.OK);

        if (string.IsNullOrEmpty(fileContent))
        {
            response.StatusCode = HttpStatusCode.NotFound;
            await response.WriteStringAsync("File not found or not yet processed.");
            return response;
        }

        await response.WriteStringAsync(fileContent);
        return response;
    }
}