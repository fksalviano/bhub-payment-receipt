using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.Factories.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.Factories;
using Application.UseCases.ProcessReceipt.Domain.Abstractions;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessor;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.DeliveryNoteSender;
using Application.Commons.MailSender;
using Application.UseCases.ProcessReceipt.Domain.ReceiptProcessors.CommissionPaymentGenerator;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt;
using Application.UseCases.ProcessReceipt.Ports;
using AutoFixture;
using Moq.AutoMock;
using Moq;
using Application.Commons.Domain;

namespace UnitTest;

public class ProcessReceiptTests
{
    private readonly IProcessReceiptUseCase _sut;
    private readonly Mock<IProcessReceiptOutputPort> _outputPort;

    private readonly Fixture _fixture = new();

    public ProcessReceiptTests()
    {        
        var mailSender = new MailSender();
        var deliveryNoteSender = new DeliveryNoteSender(mailSender);
        var commissionGenerator = new CommissionPaymentGenerator();
        var defaultProcessor = new DefaultReceiptProcessor();

        var processorFactory = new ReceiptProcessorFactory(new IReceiptProcessor[]
        {
            defaultProcessor,
            new FisicalProductProcessor(defaultProcessor, deliveryNoteSender, commissionGenerator),
            new BookProductProcessor(defaultProcessor, deliveryNoteSender, commissionGenerator, mailSender),
            new MembershipProcessor(defaultProcessor, mailSender),
            new MembershipUpgradeProcessor(defaultProcessor, mailSender)
        });

        var mocker = new AutoMocker();
        _outputPort = mocker.GetMock<IProcessReceiptOutputPort>();

        _sut = new ProcessReceiptUseCase(processorFactory);
        _sut.SetOutputPort(_outputPort.Object);
    }

    [Fact]
    public async Task Test1()
    {
        // Arrange
        var product = new Product()
        {
            Type = ProductType.Fisical
        };

        var receipt = new PaymentReceipt()
        {
            Membership = new Membership(),
            MembershipType = MembershipType.Upgrade,
            // Product = product,
            Value = 100
        };

        var input = new ProcessReceiptInput(receipt);

        // Act
        await _sut.Execute(input);

        // Assert
        _outputPort.Verify(output => output.Ok(), Times.Once);
    }
}