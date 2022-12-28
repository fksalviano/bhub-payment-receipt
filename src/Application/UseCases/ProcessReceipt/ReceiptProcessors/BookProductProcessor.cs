using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.Processors.CommissionPaymentGenerator.Abstractions;
using Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender.Abstractions;
using Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender.Extensions;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.ProcessReceipt.Processors;

public class BookProductProcessor : IReceiptProcessor
{
    private readonly IReceiptProcessor _defaultProcessor;
    private readonly IDeliveryNoteSender _deliveryNoteSender;
    private readonly IMailSender _mailSender;
    private readonly ICommissionPaymentGenerator _commissionPaymentGenerator;
    private readonly ILogger<BookProductProcessor> _logger;

    public BookProductProcessor(IDefaultReceiptProcessor defaultProcessor,
        IDeliveryNoteSender deliveryNoteSender, ICommissionPaymentGenerator commissionPaymentGenerator,
        IMailSender mailSender, ILogger<BookProductProcessor> logger)
    {
        _logger = logger;
        _defaultProcessor = defaultProcessor;

        _deliveryNoteSender = deliveryNoteSender;
        _mailSender = mailSender;
        _commissionPaymentGenerator = commissionPaymentGenerator;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);
        _logger.LogInformation($"{nameof(BookProductProcessor)}.Execute()");

        await _commissionPaymentGenerator.Execute(receipt);

        var deliveryNote = await _deliveryNoteSender.Execute(receipt);

        var royaltiesMail = deliveryNote.GetDeliveryNoteRoyaltiesMail();
        await _mailSender.SendMail(royaltiesMail);

        //TODO: separate the delivery note send from generation
    }
}
