using Azure.Storage.Blobs;
using System.Text;

const string connectionString = "UseDevelopmentStorage=true";

var options = new BlobClientOptions(BlobClientOptions.ServiceVersion.V2024_08_04);
var blobServiceClient = new BlobServiceClient(connectionString, options);

var documentsClient = blobServiceClient.GetBlobContainerClient("documents");
await documentsClient.CreateIfNotExistsAsync();

var uploadsClient = blobServiceClient.GetBlobContainerClient("uploads");
await uploadsClient.CreateIfNotExistsAsync();

const string fileName = "pipeline-test.txt";
const string content = "this text started in lowercase from the uploader!";
var bytes = Encoding.UTF8.GetBytes(content);

Console.WriteLine($"Uploading '{fileName}' to the 'uploads' container...");

using (var stream = new MemoryStream(bytes))
{
    var blobClient = uploadsClient.GetBlobClient(fileName);
    await blobClient.UploadAsync(stream, overwrite: true);
}

Console.WriteLine("Upload complete! Check the Azure Functions log.");