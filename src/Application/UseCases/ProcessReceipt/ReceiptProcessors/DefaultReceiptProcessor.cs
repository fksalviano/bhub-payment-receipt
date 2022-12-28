using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.ProcessReceipt.Processors;

public class DefaultReceiptProcessor : IDefaultReceiptProcessor
{
    private readonly ILogger<DefaultReceiptProcessor> _logger;

    public DefaultReceiptProcessor(ILogger<DefaultReceiptProcessor> logger)
    {
        _logger = logger;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        // execute all default payment receipt process common for all payment receipt processors
        await Task.Run(() => _logger.LogInformation($"{nameof(DefaultReceiptProcessor)}.Execute()"));
    }
}