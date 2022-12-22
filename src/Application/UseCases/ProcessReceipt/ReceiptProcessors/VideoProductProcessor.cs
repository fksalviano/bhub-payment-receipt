using Application.Commons.Domain;
using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.Extensions;

namespace Application.UseCases.ProcessReceipt.Domain.ReceiptProcessor;

public class VideoProductProcessor : IReceiptProcessor
{
    private readonly IReceiptProcessor _defaultProcessor;
    private readonly IMailSender _mailSender;

    public VideoProductProcessor(IReceiptProcessor defaultProcessor, IMailSender mailSender)
    {        
        _defaultProcessor = defaultProcessor;
        _mailSender = mailSender;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);

        Console.WriteLine($"{nameof(VideoProductProcessor)}.Execute()");

        //TODO: check if is specific video and send specifiC tutorial                
    }    
}
