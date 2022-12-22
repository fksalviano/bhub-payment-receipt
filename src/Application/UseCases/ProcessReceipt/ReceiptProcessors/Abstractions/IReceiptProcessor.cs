namespace Application.UseCases.ProcessReceipt.Domain.Abstractions;

public interface IReceiptProcessor
{     
    Task Execute(PaymentReceipt receipt);
}
