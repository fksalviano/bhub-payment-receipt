using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Domain;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors.Extensions;

public static class PaymentReceiptExtensions
{
    // TODO: call a builder to build the delivery note based on receipt instead return new()
    public static DeliveryNote GetDeliveryNote(this PaymentReceipt receipt) => new();
}
