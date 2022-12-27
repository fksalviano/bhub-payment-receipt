using Application.Commons.Domain;
using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.Extensions;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors;

public class MembershipProcessor : IReceiptProcessor
{
    private readonly IReceiptProcessor _defaultProcessor;
    private readonly IMailSender _mailSender;

    public MembershipProcessor(IDefaultReceiptProcessor defaultProcessor, IMailSender mailSender)
    {        
        _defaultProcessor = defaultProcessor;        
        _mailSender = mailSender;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);
        Console.WriteLine($"{nameof(MembershipProcessor)}.Execute()");

        ActivateMembership(receipt.Membership);

        var membershipMail = receipt.Membership.GetMembershipMail(MembershipType.New);
        await _mailSender.SendMail(membershipMail);
    }

    private void ActivateMembership(Membership? membership)
    {
        // TODO: implement membership activation
    }
}
