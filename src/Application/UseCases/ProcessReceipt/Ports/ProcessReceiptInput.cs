using Application.UseCases.ProcessReceipt;

namespace Application.UseCases.ProcessReceipt.Ports;

public record ProcessReceiptInput(PaymentReceipt Receipt);