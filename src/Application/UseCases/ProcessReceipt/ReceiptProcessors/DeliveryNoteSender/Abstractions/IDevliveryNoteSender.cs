using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender.Domain;

namespace Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender.Abstractions;

public interface IDeliveryNoteSender
{
    Task<DeliveryNote> Execute(PaymentReceipt receipt);
}
