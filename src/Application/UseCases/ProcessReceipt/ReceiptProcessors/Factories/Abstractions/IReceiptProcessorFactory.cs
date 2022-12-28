using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;

namespace Application.UseCases.ProcessReceipt.Processors.Factories.Abstractions;

public interface IReceiptProcessorFactory
{
    IReceiptProcessor GetProcessor(PaymentReceipt receipt);
}
