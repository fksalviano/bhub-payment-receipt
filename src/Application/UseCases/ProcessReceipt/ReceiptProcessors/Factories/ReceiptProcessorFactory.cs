using Application.Commons.Domain;
using Application.Commons.Extensions;
using Application.UseCases.ProcessReceipt.Domain.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessor;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.Extensions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.Factories.Abstractions;
using static Application.Commons.Domain.MembershipType;
using static Application.Commons.Domain.ProductType;

namespace Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.Factories;

public class ReceiptProcessorFactory : IReceiptProcessorFactory
{
    private readonly IEnumerable<IReceiptProcessor> _receiptProcessors;

    public ReceiptProcessorFactory(IEnumerable<IReceiptProcessor> receiptProcessors)
    {
        _receiptProcessors = receiptProcessors;
    }

    public IReceiptProcessor GetProcessor(PaymentReceipt receipt)
    {
        if (receipt.Product is not null)
        {
            return receipt.Product.Value.Type switch
            {
                Fisical =>
                    GetProcessorType(typeof(FisicalProductProcessor)),
                Book =>
                    GetProcessorType(typeof(BookProductProcessor)),
                Video =>
                    GetProcessorType(typeof(VideoProductProcessor)),
                _ =>
                    throw new ArgumentOutOfRangeException()
            };
        }

        if (receipt.Membership is not null)
        {
            if (receipt.MembershipType == Upgrade)
                return GetProcessorType(typeof(MembershipUpgradeProcessor));
            
            return GetProcessorType(typeof(MembershipProcessor));
        }

        return GetProcessorType(typeof(DefaultReceiptProcessor));
    }

    private IReceiptProcessor GetProcessorType(Type processorType) =>
        _receiptProcessors.First(p => p.GetType().Name == processorType.Name);
}
