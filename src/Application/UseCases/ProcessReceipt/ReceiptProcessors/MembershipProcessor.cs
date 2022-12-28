using Application.Commons.Domain;
using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.Processors.Extensions;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.ProcessReceipt.Processors;

public class MembershipProcessor : IReceiptProcessor
{
    private readonly IReceiptProcessor _defaultProcessor;
    private readonly IMailSender _mailSender;
        private readonly ILogger<MembershipProcessor> _logger;

    public MembershipProcessor(IDefaultReceiptProcessor defaultProcessor, IMailSender mailSender,
        ILogger<MembershipProcessor> logger)
    {
        _logger = logger;
        _defaultProcessor = defaultProcessor;

        _mailSender = mailSender;
    }

    public async Task Execute(PaymentReceipt receipt)
    {
        await _defaultProcessor.Execute(receipt);
        _logger.LogInformation($"{nameof(MembershipProcessor)}.Execute()");

        ActivateMembership(receipt.Membership);

        var membershipMail = receipt.Membership.GetMembershipMail(MembershipType.New);
        await _mailSender.SendMail(membershipMail);
    }

    private void ActivateMembership(Membership? membership)
    {
        // TODO: implement membership activation
    }
}
