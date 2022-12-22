using Application.Commons.Domain;
using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.Extensions;

namespace Application.UseCases.ProcessReceipt.Domain.ReceiptProcessor;

public class MembershipUpgradeProcessor : IReceiptProcessor
{
    private readonly IReceiptProcessor _defaultProcessor;
    private readonly IMailSender _mailSender;

    public MembershipUpgradeProcessor(IReceiptProcessor defaultProcessor, IMailSender mailSender)
    {
        _defaultProcessor = defaultProcessor;
        _mailSender = mailSender;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);

        Console.WriteLine($"{nameof(MembershipUpgradeProcessor)}.Execute()");

        UpgradeMembership(receipt.Membership);

        var membershipMail = receipt.Membership.GetMembershipMail(receipt.MembershipType);
        await _mailSender.SendMail(membershipMail);
    }

    private void UpgradeMembership(Membership? membership)
    {
        // TODO: implement membership upgrade
    }
}
