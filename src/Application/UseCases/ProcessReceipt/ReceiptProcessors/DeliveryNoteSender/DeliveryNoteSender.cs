using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Abstractions;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Domain;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Extensions;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.Extensions;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender;

public class DeliveryNoteSender : IDeliveryNoteSender
{
    private readonly IMailSender _mailSender;

    public DeliveryNoteSender(IMailSender mailSender)
    {
        _mailSender = mailSender;
    }

    public async Task<DeliveryNote> Execute(PaymentReceipt receipt)
    {
        Console.WriteLine($"{nameof(DeliveryNoteSender)}.Execute()");

        var deliveryNote = receipt.GetDeliveryNote();

        var mail = deliveryNote.GetDeliveryNoteMail();
        await _mailSender.SendMail(mail);

        return deliveryNote;
    }
}
