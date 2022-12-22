using Application.Commons.Domain;
using Application.UseCases.ProcessReceipt.Domain.Abstractions;

namespace Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors;

public class DefaultReceiptProcessor : IReceiptProcessor
{
    public async Task Execute(PaymentReceipt receipt)
    {
        // execute all default payment receipt process common for all payment receipt

        await Task.Run(() => Console.WriteLine($"{nameof(DefaultReceiptProcessor)}.Execute()"));
    }
}