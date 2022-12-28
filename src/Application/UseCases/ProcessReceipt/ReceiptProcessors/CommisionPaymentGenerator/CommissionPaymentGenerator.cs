using Application.UseCases.ProcessReceipt.Processors.CommissionPaymentGenerator.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.ProcessReceipt.Processors.CommissionPaymentGenerator;

public class CommissionPaymentGenerator : ICommissionPaymentGenerator
{
    private readonly ILogger<CommissionPaymentGenerator> _logger;

    public CommissionPaymentGenerator(ILogger<CommissionPaymentGenerator> logger)
    {
        _logger = logger;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await Task.Run(() => _logger.LogInformation($"{nameof(CommissionPaymentGenerator)}.Execute()"));
    }
}
