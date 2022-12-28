using Application.Commons.MailSender.Abstractions;
using Application.Commons.MailSender.Domain;
using Microsoft.Extensions.Logging;

namespace Application.Commons.MailSender;

public class MailSender : IMailSender
{
    private readonly ILogger<MailSender> _logger;

    public MailSender(ILogger<MailSender> logger)
    {
        _logger = logger;
    }

    public async Task SendMail(Mail mail)
    {
        await Task.Run(() => _logger.LogInformation($"{nameof(MailSender)}.Execute()"));
    }
}
