using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender.Domain;

namespace Application.UseCases.ProcessReceipt.Processors.Extensions;

public static class PaymentReceiptExtensions
{
    // TODO: call a builder to build the delivery note based on receipt instead return new()
    public static DeliveryNote GetDeliveryNote(this PaymentReceipt receipt) => new();
}
