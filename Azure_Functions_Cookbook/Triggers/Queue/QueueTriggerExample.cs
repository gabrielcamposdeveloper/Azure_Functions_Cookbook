using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionsCookbook;

public class QueueTriggerExample
{
    private readonly ILogger<QueueTriggerExample> _logger;

    public QueueTriggerExample(ILogger<QueueTriggerExample> logger)
    {
        _logger = logger;
    }

    [Function(nameof(QueueTriggerExample))]
    public void Run([QueueTrigger("orders")] string message)
    {
        _logger.LogInformation("==============================================");
        _logger.LogInformation(" 🚀 [NEW MESSAGE DETECTED IN QUEUE] 🚀 ");
        _logger.LogInformation(" 📦 Message Content: {message}", message);
        _logger.LogInformation("==============================================");
    }
}