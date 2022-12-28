using Application.UseCases.ProcessReceipt.Ports;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Processors.Factories.Abstractions;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.ProcessReceipt;

public class ProcessReceiptUseCase : IProcessReceiptUseCase
{
    private readonly IReceiptProcessorFactory _processorFactory;
    private readonly ILogger<ProcessReceiptUseCase> _logger;
    private IProcessReceiptOutputPort _outputPort = null!;

    public void SetOutputPort(IProcessReceiptOutputPort outputPort) =>
        _outputPort = outputPort;

    public ProcessReceiptUseCase(IReceiptProcessorFactory processorFactory,
        ILogger<ProcessReceiptUseCase> logger)
    {
        _logger = logger;
        _processorFactory = processorFactory;
    }

    public async Task Execute(ProcessReceiptInput input)
    {
        var receipt = input.Receipt;

        var receiptProcessor = _processorFactory.GetProcessor(receipt);
        _logger.LogInformation(receiptProcessor.GetType().Name);

        await receiptProcessor.Execute(receipt);

        _outputPort.Ok();
    }
}