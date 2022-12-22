using Application.Commons.MailSender.Abstractions;
using Application.Commons.MailSender.Domain;

namespace Application.Commons.MailSender;

public class MailSender : IMailSender
{
    public async Task SendMail(Mail mail)
    {
        await Task.Run(() => Console.WriteLine($"{nameof(MailSender)}.Execute()"));
    }
}
