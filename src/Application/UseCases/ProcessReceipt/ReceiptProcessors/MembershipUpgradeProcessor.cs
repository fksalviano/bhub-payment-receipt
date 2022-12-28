using Application.Commons.Domain;
using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.Processors.Extensions;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.ProcessReceipt.Processors;

public class MembershipUpgradeProcessor : IReceiptProcessor
{
    private readonly IReceiptProcessor _defaultProcessor;
    private readonly IMailSender _mailSender;
    private readonly ILogger<MembershipUpgradeProcessor> _logger;

    public MembershipUpgradeProcessor(IDefaultReceiptProcessor defaultProcessor, IMailSender mailSender,
        ILogger<MembershipUpgradeProcessor> logger)
    {
        _logger = logger;
        _defaultProcessor = defaultProcessor;

        _mailSender = mailSender;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);
        _logger.LogInformation($"{nameof(MembershipUpgradeProcessor)}.Execute()");

        UpgradeMembership(receipt.Membership);

        var membershipMail = receipt.Membership.GetMembershipMail(MembershipType.Upgrade);
        await _mailSender.SendMail(membershipMail);
    }

    private void UpgradeMembership(Membership? membership)
    {
        // TODO: implement the membership upgrade
    }
}
