using Application.UseCases.ProcessReceipt.Domain.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.CommissionPaymentGenerator.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.DeliveryNoteSender.Abstractions;

namespace Application.UseCases.ProcessReceipt.Domain.ReceiptProcessor;

public class FisicalProductProcessor : IReceiptProcessor
{
    private readonly IReceiptProcessor _defaultProcessor;
    private readonly IDeliveryNoteSender _deliveryNoteSender;
    private readonly ICommissionPaymentGenerator _commissionPaymentGenerator;

    public FisicalProductProcessor(IReceiptProcessor defaultProcessor,
        IDeliveryNoteSender deliveryNoteSender, ICommissionPaymentGenerator commissionPaymentGenerator)
    {
        _defaultProcessor = defaultProcessor;
        _deliveryNoteSender = deliveryNoteSender;
        _commissionPaymentGenerator = commissionPaymentGenerator;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);

        Console.WriteLine($"{nameof(FisicalProductProcessor)}.Execute()");

        await _commissionPaymentGenerator.Execute(receipt);
        await _deliveryNoteSender.Execute(receipt);
    }
}
