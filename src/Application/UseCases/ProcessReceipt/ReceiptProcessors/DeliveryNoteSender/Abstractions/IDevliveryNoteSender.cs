using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Domain;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Abstractions;

public interface IDeliveryNoteSender
{
    Task<DeliveryNote> Execute(PaymentReceipt receipt);
}
