using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.Ports;

namespace Worker.Controllers;

[ApiController]
[Route("process-receipt")]
public class ProcessReceiptController: Controller, IProcessReceiptOutputPort
{
    private readonly IProcessReceiptUseCase _processReceiptUseCase;
    private IActionResult? _viewModel;

    public ProcessReceiptController(IProcessReceiptUseCase processReceiptUseCase)
    {
        _processReceiptUseCase = processReceiptUseCase;
        _processReceiptUseCase.SetOutputPort(this);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PaymentReceipt receipt)
    {
        var input = new ProcessReceiptInput(receipt);

        await _processReceiptUseCase.Execute(input);

        return _viewModel!;
    }

    void IProcessReceiptOutputPort.Ok() => 
        _viewModel = Ok();

    void IProcessReceiptOutputPort.Invalid(string message) => 
        BadRequest(message);

    void IProcessReceiptOutputPort.Error(string message) =>
        StatusCode(StatusCodes.Status500InternalServerError, message);
}
