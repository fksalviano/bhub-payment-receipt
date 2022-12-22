using Application.Commons.Domain;

namespace Application.UseCases.ProcessReceipt.Domain;

public class PaymentReceipt
{
    public Product? Product { get; set; }
    public Membership? Membership { get; set; }
    public MembershipType? MembershipType { get; set; }
    public decimal Value { get; set; }
}
