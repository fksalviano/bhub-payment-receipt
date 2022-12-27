using Application.Commons.Domain;
using Application.Commons.MailSender.Domain;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors.Extensions;

public static class MembershipExtensions
{
    // TODO: call a builder to build the membership mail based on membership type

    public static Mail GetMembershipMail(this Membership? membership, MembershipType? type) =>
        new Mail("test", "test", "test");
}
