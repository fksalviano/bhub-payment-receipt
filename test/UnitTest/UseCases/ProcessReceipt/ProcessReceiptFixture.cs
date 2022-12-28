using Application.Commons.MailSender;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Processors;
using Application.UseCases.ProcessReceipt.Processors.CommissionPaymentGenerator;
using Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender;
using Application.UseCases.ProcessReceipt.Processors.Factories;
using Microsoft.Extensions.Logging;
using Moq.AutoMock;

namespace UnitTest.UseCases.ProcessReceipt.ReceiptProcessors;

public class ProcessReceiptFixture
{

    private readonly AutoMocker _mocker = new();

    public ReceiptProcessorFactory GetProcessorFactory()
    {
        var mailSender = new MailSender(GetLog<MailSender>());
        var deliveryNoteSender = new DeliveryNoteSender(mailSender, GetLog<DeliveryNoteSender>());
        var commissionGenerator = new CommissionPaymentGenerator(GetLog<CommissionPaymentGenerator>());
        var defaultProcessor = new DefaultReceiptProcessor(GetLog<DefaultReceiptProcessor>());

        return new ReceiptProcessorFactory(new IReceiptProcessor[]
        {
            defaultProcessor,

            new FisicalProductProcessor(defaultProcessor,
                deliveryNoteSender, commissionGenerator, GetLog<FisicalProductProcessor>()),

            new BookProductProcessor(defaultProcessor,
                deliveryNoteSender, commissionGenerator, mailSender, GetLog<BookProductProcessor>()),

            new VideoProductProcessor(defaultProcessor,
                mailSender, GetLog<VideoProductProcessor>()),

            new MembershipProcessor(defaultProcessor,
                mailSender, GetLog<MembershipProcessor>()),

            new MembershipUpgradeProcessor(defaultProcessor,
                mailSender, GetLog<MembershipUpgradeProcessor>())
        });
    }

    private ILogger<T> GetLog<T>() => _mocker.GetMock<ILogger<T>>().Object;
}