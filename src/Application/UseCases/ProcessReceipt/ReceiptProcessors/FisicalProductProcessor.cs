using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.Processors.CommissionPaymentGenerator.Abstractions;
using Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender.Abstractions;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.ProcessReceipt.Processors;

public class FisicalProductProcessor : IReceiptProcessor
{
    private IReceiptProcessor _defaultProcessor = null!;
    private readonly IDeliveryNoteSender _deliveryNoteSender;
    private readonly ICommissionPaymentGenerator _commissionPaymentGenerator;
    private readonly ILogger<FisicalProductProcessor> _logger;

    public FisicalProductProcessor(IDefaultReceiptProcessor defaultProcessor,
        IDeliveryNoteSender deliveryNoteSender, ICommissionPaymentGenerator commissionPaymentGenerator,
        ILogger<FisicalProductProcessor> logger)
    {
        _logger = logger;
        _defaultProcessor = defaultProcessor;

        _deliveryNoteSender = deliveryNoteSender;
        _commissionPaymentGenerator = commissionPaymentGenerator;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);
        _logger.LogInformation($"{nameof(FisicalProductProcessor)}.Execute()");

        await _commissionPaymentGenerator.Execute(receipt);
        await _deliveryNoteSender.Execute(receipt);
    }
}
