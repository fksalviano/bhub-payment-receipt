namespace Application.UseCases.ProcessReceipt.Abstractions;

public interface IReceiptProcessor
{
    Task Execute(PaymentReceipt receipt);
}
