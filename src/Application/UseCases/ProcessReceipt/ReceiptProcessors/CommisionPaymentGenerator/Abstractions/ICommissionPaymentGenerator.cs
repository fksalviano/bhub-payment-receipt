namespace Application.UseCases.ProcessReceipt.ReceiptProcessors.CommissionPaymentGenerator.Abstractions;

public interface ICommissionPaymentGenerator
{
    Task Execute(PaymentReceipt receipt);
}
