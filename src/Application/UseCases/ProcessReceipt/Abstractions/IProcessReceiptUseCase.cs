using Application.UseCases.ProcessReceipt.Ports;

namespace Application.UseCases.ProcessReceipt.Abstractions;

public interface IProcessReceiptUseCase
{
    void SetOutputPort(IProcessReceiptOutputPort outputPort);

    Task Execute(ProcessReceiptInput input);
}
