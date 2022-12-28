using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender.Abstractions;
using Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender.Domain;
using Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender.Extensions;
using Application.UseCases.ProcessReceipt.Processors.Extensions;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender;

public class DeliveryNoteSender : IDeliveryNoteSender
{
    private readonly IMailSender _mailSender;
    private readonly ILogger<DeliveryNoteSender> _logger;

    public DeliveryNoteSender(IMailSender mailSender, ILogger<DeliveryNoteSender> logger)
    {
        _logger = logger;
        _mailSender = mailSender;
    }

    public async Task<DeliveryNote> Execute(PaymentReceipt receipt)
    {
        _logger.LogInformation($"{nameof(DeliveryNoteSender)}.Execute()");

        var deliveryNote = receipt.GetDeliveryNote();

        var mail = deliveryNote.GetDeliveryNoteMail();
        await _mailSender.SendMail(mail);

        return deliveryNote;
    }
}
