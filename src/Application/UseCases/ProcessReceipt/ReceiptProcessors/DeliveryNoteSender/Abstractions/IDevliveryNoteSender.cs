using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.DeliveryNoteSender.Domain;

namespace Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.DeliveryNoteSender.Abstractions;

public interface IDeliveryNoteSender
{
    Task<DeliveryNote> Execute(PaymentReceipt receipt);
}
