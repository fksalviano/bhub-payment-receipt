using Application.UseCases.ProcessReceipt.Abstractions;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors.Factories.Abstractions;

public interface IReceiptProcessorFactory
{
    IReceiptProcessor GetProcessor(PaymentReceipt receipt);
}
