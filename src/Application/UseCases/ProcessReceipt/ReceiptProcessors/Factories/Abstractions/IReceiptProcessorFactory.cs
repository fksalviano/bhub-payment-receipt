using Application.UseCases.ProcessReceipt.Domain.Abstractions;

namespace Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.Factories.Abstractions;

public interface IReceiptProcessorFactory
{
    IReceiptProcessor GetProcessor(PaymentReceipt receipt);
}
