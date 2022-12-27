using Application.UseCases.ProcessReceipt.Domain;

namespace Application.UseCases.ProcessReceipt.Abstractions;

public interface IReceiptProcessor
{
    Task Execute(PaymentReceipt receipt);
}
