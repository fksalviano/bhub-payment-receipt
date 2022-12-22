using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.CommissionPaymentGenerator.Abstractions;

namespace Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.CommissionPaymentGenerator;

public class CommissionPaymentGenerator : ICommissionPaymentGenerator
{
    public async Task Execute(PaymentReceipt receipt)
    {
        await Task.Run(() => Console.WriteLine($"{nameof(CommissionPaymentGenerator)}.Execute()"));
    }
}
