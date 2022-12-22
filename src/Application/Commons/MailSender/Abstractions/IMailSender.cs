using Application.Commons.MailSender.Domain;

namespace Application.Commons.MailSender.Abstractions;

public interface IMailSender
{
    Task SendMail(Mail mail);
}
