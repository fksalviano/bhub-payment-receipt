using Application.Commons.Extensions;
using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.Abstractions;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.ProcessReceipt.Processors;

public class VideoProductProcessor : IReceiptProcessor
{
    private readonly IReceiptProcessor _defaultProcessor;
    private readonly IMailSender _mailSender;
    private readonly ILogger<VideoProductProcessor> _logger;

    public VideoProductProcessor(IDefaultReceiptProcessor defaultProcessor, IMailSender mailSender,
        ILogger<VideoProductProcessor> logger)
    {
        _logger = logger;
        _defaultProcessor = defaultProcessor;

        _mailSender = mailSender;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);
        _logger.LogInformation($"{nameof(VideoProductProcessor)}.Execute()");

        if (receipt.Product?.Video?.TutorialVideo is not null)
        {
            var tutorialVideoMail = receipt.Product.GetVideoTutorialMail();
            await _mailSender.SendMail(tutorialVideoMail);
        }
    }
}
