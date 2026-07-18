using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsCookbook;

public class BlobTriggerExample
{
    private readonly ILogger<BlobTriggerExample> _logger;

    // Injeção de dependência para usar o Logger oficial do .NET
    public BlobTriggerExample(ILogger<BlobTriggerExample> logger)
    {
        _logger = logger;
    }

    [Function(nameof(BlobTriggerExample))]
    public void Run([BlobTrigger("uploads/{name}")] Stream blob, string name)
    {
        _logger.LogInformation("==============================================");
        _logger.LogInformation(" 🚀 [NOVO ARQUIVO DETECTADO NO STORAGE] 🚀 ");
        _logger.LogInformation(" 📂 Nome do Arquivo : {name}", name);
        _logger.LogInformation(" 📏 Tamanho         : {size} bytes", blob.Length);
        _logger.LogInformation("==============================================");
    }
}