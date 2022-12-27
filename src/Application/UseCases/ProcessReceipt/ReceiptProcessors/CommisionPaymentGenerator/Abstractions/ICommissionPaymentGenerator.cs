using Application.UseCases.ProcessReceipt.Domain;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors.CommissionPaymentGenerator.Abstractions;

public interface ICommissionPaymentGenerator
{
    Task Execute(PaymentReceipt receipt);
}
