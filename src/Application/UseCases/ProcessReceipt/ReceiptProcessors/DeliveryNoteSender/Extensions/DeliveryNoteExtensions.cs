using Application.Commons.MailSender.Domain;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Domain;

namespace Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Extensions;

public static class DeliveryNoteExtensions
{
    // TODO: call a builder to build the delivery note mail based on delivery note instead new Mail()

    public static Mail GetDeliveryNoteMail(this DeliveryNote deliveryNote) =>
        new Mail("test", "test", "test");

    public static Mail GetDeliveryNoteRoyaltiesMail(this DeliveryNote deliveryNote) =>
        new Mail("test", "test", "test");
}
