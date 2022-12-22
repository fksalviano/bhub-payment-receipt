using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.DeliveryNoteSender.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.DeliveryNoteSender.Domain;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.DeliveryNoteSender.Extensions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.Extensions;

namespace Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.DeliveryNoteSender;

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