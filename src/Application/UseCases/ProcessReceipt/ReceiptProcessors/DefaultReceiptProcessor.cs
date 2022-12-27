using Application.UseCases.ProcessReceipt.Abstractions;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors;

public class DefaultReceiptProcessor : IDefaultReceiptProcessor
{
    public async Task Execute(PaymentReceipt receipt)
    {
        // execute all default payment receipt process common for all payment receipt processors
        await Task.Run(() => Console.WriteLine($"{nameof(DefaultReceiptProcessor)}.Execute()"));
    }
}