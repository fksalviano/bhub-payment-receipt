using Application.Commons.Domain;
using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.Extensions;

namespace Application.UseCases.ProcessReceipt.Domain.ReceiptProcessor;

public class MembershipProcessor : IReceiptProcessor
{
    private readonly IReceiptProcessor _defaultProcessor;
    private readonly IMailSender _mailSender;

    public MembershipProcessor(IReceiptProcessor defaultProcessor, IMailSender mailSender)
    {        
        _defaultProcessor = defaultProcessor;
        _mailSender = mailSender;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);

        Console.WriteLine($"{nameof(MembershipProcessor)}.Execute()");

        ActivateMembership(receipt.Membership);

        var membershipMail = receipt.Membership.GetMembershipMail(receipt.MembershipType);
        await _mailSender.SendMail(membershipMail);
    }

    private void ActivateMembership(Membership? membership)
    {
        // TODO: implement membership activation
    }
}
