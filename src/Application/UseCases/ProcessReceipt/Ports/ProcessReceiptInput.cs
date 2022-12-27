using Application.UseCases.ProcessReceipt.Domain;

namespace Application.UseCases.ProcessReceipt.Ports;

public record ProcessReceiptInput(PaymentReceipt Receipt);