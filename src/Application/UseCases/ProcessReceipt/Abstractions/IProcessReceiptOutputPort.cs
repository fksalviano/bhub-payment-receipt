using Application.UseCases.ProcessReceipt.Ports;

namespace Application.UseCases.ProcessReceipt.Abstractions;

public interface IProcessReceiptOutputPort
{
    void Ok();
    void Invalid(string message);
    void Error(string message);
}
