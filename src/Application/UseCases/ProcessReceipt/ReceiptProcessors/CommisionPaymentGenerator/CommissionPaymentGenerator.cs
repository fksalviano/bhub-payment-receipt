using Application.UseCases.ProcessReceipt.ReceiptProcessors.CommissionPaymentGenerator.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors.CommissionPaymentGenerator;

public class CommissionPaymentGenerator : ICommissionPaymentGenerator
{
    public async Task Execute(PaymentReceipt receipt)
    {
        await Task.Run(() => Console.WriteLine($"{nameof(CommissionPaymentGenerator)}.Execute()"));
    }
}
