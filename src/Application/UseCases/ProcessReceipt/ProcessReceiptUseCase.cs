using Application.UseCases.ProcessReceipt.Ports;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.Factories.Abstractions;

namespace Application.UseCases.ProcessReceipt;

public class ProcessReceiptUseCase : IProcessReceiptUseCase
{
    private readonly IReceiptProcessorFactory _processorFactory;
    private IProcessReceiptOutputPort _outputPort = null!;
    
    public void SetOutputPort(IProcessReceiptOutputPort outputPort) =>
        _outputPort = outputPort;    

    public ProcessReceiptUseCase(IReceiptProcessorFactory processorFactory)
    {
        _processorFactory = processorFactory;
    }    

    public async Task Execute(ProcessReceiptInput input)
    {       
        if (input.Receipt is null)
        {
            _outputPort.Invalid("Receipt is null");
            return;
        }
        
        var receipt = input.Receipt;
        var receiptProcessor = _processorFactory.GetProcessor(receipt);
        
        await receiptProcessor.Execute(receipt);

        _outputPort.Ok();        
    }    
}
