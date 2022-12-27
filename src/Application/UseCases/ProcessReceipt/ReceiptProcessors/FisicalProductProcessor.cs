using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.CommissionPaymentGenerator.Abstractions;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Abstractions;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors;

public class FisicalProductProcessor : IReceiptProcessor
{
    private IReceiptProcessor _defaultProcessor = null!;
    private readonly IDeliveryNoteSender _deliveryNoteSender;
    private readonly ICommissionPaymentGenerator _commissionPaymentGenerator;

    public FisicalProductProcessor(IDefaultReceiptProcessor defaultProcessor,
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
