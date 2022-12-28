using Application.UseCases.ProcessReceipt.Domain;

namespace Application.UseCases.ProcessReceipt.Processors.CommissionPaymentGenerator.Abstractions;

public interface ICommissionPaymentGenerator
{
    Task Execute(PaymentReceipt receipt);
}
