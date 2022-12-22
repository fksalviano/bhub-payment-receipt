namespace Application.Commons.MailSender.Domain;

public class Mail
{    
    public string From { get; }   
    public string To { get; }
    public string Body { get; }

    public Mail(string from, string to, string body)
    {
        From = from;
        To = to;
        Body = body;
    }
}
