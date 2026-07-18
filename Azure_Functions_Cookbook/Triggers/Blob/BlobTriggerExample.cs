using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;

namespace AzureFunctionsCookbook;

public class BlobTriggerExample
{
    [Function(nameof(BlobTriggerExample))]
    public void Run([BlobTrigger("uploads/{name}")] Stream blob, string name)
    {
        Console.WriteLine(name);
    }
}