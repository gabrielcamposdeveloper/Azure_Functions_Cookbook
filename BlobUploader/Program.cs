using Azure.Storage.Blobs;
using System.Text;

const string connectionString = "UseDevelopmentStorage=true";

// 1. Força o SDK a usar uma versão de API suportada pelo Azurite atual
var options = new BlobClientOptions(BlobClientOptions.ServiceVersion.V2024_08_04);
var blobServiceClient = new BlobServiceClient(connectionString, options);

// 2. Prepara o container 'documents' (Para o seu teste de Input Binding via HTTP GET)
var documentsClient = blobServiceClient.GetBlobContainerClient("documents");
await documentsClient.CreateIfNotExistsAsync();

// 3. Prepara o container 'uploads' (Para disparar o seu BlobTriggerExample automaticamente)
var uploadsClient = blobServiceClient.GetBlobContainerClient("uploads");
await uploadsClient.CreateIfNotExistsAsync();

const string content = "Hello Azure Functions!";
var bytes = Encoding.UTF8.GetBytes(content);

// 4. Faz o upload para o 'documents'
using (var stream1 = new MemoryStream(bytes))
{
    // Pegamos a referência direta do arquivo dentro do container
    var blobClient1 = documentsClient.GetBlobClient("sample.txt");
    
    // Agora sim usamos o UploadAsync (que aceita o overwrite)
    await blobClient1.UploadAsync(stream1, overwrite: true);
}

// 5. Faz o upload para o 'uploads'
using (var stream2 = new MemoryStream(bytes))
{
    // Pegamos a referência direta do arquivo dentro do container
    var blobClient2 = uploadsClient.GetBlobClient("sample.txt");
    
    // Fazemos o upload permitindo sobrescrever
    await blobClient2.UploadAsync(stream2, overwrite: true);
}

Console.WriteLine("Sucesso absoluto! Blobs criados em 'documents' e 'uploads'.");