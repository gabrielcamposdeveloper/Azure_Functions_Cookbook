using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json.Linq;

public class CosmosDbTriggerExample
{
    [Function("CosmosDbTriggerExample")]
    public void Run(
        [CosmosDBTrigger(
            databaseName: "SampleDb",
            containerName: "Orders",
            Connection = "CosmosConnection")]
        IReadOnlyList<JObject> input)
    {
        Console.WriteLine(input.Count);
    }
}