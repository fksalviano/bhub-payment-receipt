using Application.Commons.MailSender;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.ReceiptProcessors;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.CommissionPaymentGenerator;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.Factories;

namespace UnitTest.UseCases.ProcessReceipt.ReceiptProcessors;

public class ProcessReceiptFixture
{    
    public ReceiptProcessorFactory GetProcessorFactory()
    {
        var mailSender = new MailSender();
        var deliveryNoteSender = new DeliveryNoteSender(mailSender);
        var commissionGenerator = new CommissionPaymentGenerator();
        var defaultProcessor = new DefaultReceiptProcessor();

        return new ReceiptProcessorFactory(new IReceiptProcessor[]
        {
            defaultProcessor,
            new FisicalProductProcessor(defaultProcessor, deliveryNoteSender, commissionGenerator),
            new BookProductProcessor(defaultProcessor, deliveryNoteSender, commissionGenerator, mailSender),
            new VideoProductProcessor(defaultProcessor, mailSender),
            new MembershipProcessor(defaultProcessor, mailSender),
            new MembershipUpgradeProcessor(defaultProcessor, mailSender)
        });
    }
}