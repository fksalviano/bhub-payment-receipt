using Application.Commons.Domain;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.Factories.Abstractions;
using static Application.Commons.Domain.MembershipType;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors.Factories;

public class ReceiptProcessorFactory : IReceiptProcessorFactory
{
    private readonly IEnumerable<IReceiptProcessor> _receiptProcessors;

    public ReceiptProcessorFactory(IEnumerable<IReceiptProcessor> receiptProcessors) =>
        _receiptProcessors = receiptProcessors;    

    public IReceiptProcessor GetProcessor(PaymentReceipt receipt)
    {
        if (receipt.Product is not null)
        {
            return receipt.Product.Type switch
            {
                ProductType.Fisical => GetProcessor<FisicalProductProcessor>(),
                ProductType.Book    => GetProcessor<BookProductProcessor>(),
                ProductType.Video   => GetProcessor<VideoProductProcessor>(),
                _ => 
                    GetProcessor<DefaultReceiptProcessor>()
            };
        }

        if (receipt.Membership is not null)
        {
            if (receipt.MembershipType == Upgrade)
                return GetProcessor<MembershipUpgradeProcessor>();

            return GetProcessor<MembershipProcessor>();
        }

        return GetProcessor<DefaultReceiptProcessor>();
    }

    private IReceiptProcessor GetProcessor<T>() => 
        _receiptProcessors.First(p => p.GetType() == typeof(T));
}
