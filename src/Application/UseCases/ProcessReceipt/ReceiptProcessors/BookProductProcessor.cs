using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.CommissionPaymentGenerator.Abstractions;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Abstractions;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Extensions;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors;

public class BookProductProcessor : IReceiptProcessor
{
    private readonly IReceiptProcessor _defaultProcessor;
    private readonly IDeliveryNoteSender _deliveryNoteSender;
    private readonly IMailSender _mailSender;
    private readonly ICommissionPaymentGenerator _commissionPaymentGenerator;

    public BookProductProcessor(IDefaultReceiptProcessor defaultProcessor, 
        IDeliveryNoteSender deliveryNoteSender, ICommissionPaymentGenerator commissionPaymentGenerator,
        IMailSender mailSender)
    {
        _defaultProcessor = defaultProcessor;
        
        _deliveryNoteSender = deliveryNoteSender;
        _mailSender = mailSender;
        _commissionPaymentGenerator = commissionPaymentGenerator;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);
        Console.WriteLine($"{nameof(BookProductProcessor)}.Execute()");

        await _commissionPaymentGenerator.Execute(receipt);
        
        var deliveryNote = await _deliveryNoteSender.Execute(receipt);

        var royaltiesMail = deliveryNote.GetDeliveryNoteRoyaltiesMail();
        await _mailSender.SendMail(royaltiesMail);

        //TODO: separate the delivery note send from generation
    }
}
