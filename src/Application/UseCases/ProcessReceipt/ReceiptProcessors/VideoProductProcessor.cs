using Application.Commons.Extensions;
using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Abstractions;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors;

public class VideoProductProcessor : IReceiptProcessor
{
    private readonly IReceiptProcessor _defaultProcessor;
    private readonly IMailSender _mailSender;    

    public VideoProductProcessor(IDefaultReceiptProcessor defaultProcessor, IMailSender mailSender)
    {
        _defaultProcessor = defaultProcessor;
        _mailSender = mailSender;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);
        Console.WriteLine($"{nameof(VideoProductProcessor)}.Execute()");

        if (receipt.Product?.Video?.TutorialVideo is not null)
        {
            var tutorialVideoMail = receipt.Product.GetVideoTutorialMail();
            await _mailSender.SendMail(tutorialVideoMail);
        }
    }
}
