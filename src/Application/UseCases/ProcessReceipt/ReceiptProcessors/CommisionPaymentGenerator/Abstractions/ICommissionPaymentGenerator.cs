namespace Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.CommissionPaymentGenerator.Abstractions;

public interface ICommissionPaymentGenerator
{
    Task Execute(PaymentReceipt receipt);
}
