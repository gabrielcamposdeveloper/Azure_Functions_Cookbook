using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsCookbook;

public class BlobTriggerExample
{
    private readonly ILogger<BlobTriggerExample> _logger;

    public BlobTriggerExample(ILogger<BlobTriggerExample> logger)
    {
        _logger = logger;
    }

    [Function(nameof(BlobTriggerExample))]
    [BlobOutput("documents/{name}")] // OUTPUT: Salva o RETORNO deste método nesta pasta
    public string Run(
        [BlobTrigger("uploads/{name}")] string fileContent, // TRIGGER: Pede a string direto!
        string name)
    {
        _logger.LogInformation("⚙️ [TRIGGER DISPARADO] Lendo arquivo: {name}", name);

        // Processa os dados (transforma em maiúsculas)
        var processedContent = fileContent.ToUpper() + "\n\n[PROCESSADO COM SUCESSO PELO BLOB TRIGGER!]";
        
        _logger.LogInformation("✅ Processamento concluído. Salvando na pasta 'documents'.");

        // O retorno vira o arquivo novo na pasta 'documents'
        return processedContent;
    }
}