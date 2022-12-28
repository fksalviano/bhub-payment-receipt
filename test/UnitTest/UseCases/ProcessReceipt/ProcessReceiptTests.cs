using Application.UseCases.ProcessReceipt;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Domain;
using Application.UseCases.ProcessReceipt.Ports;
using Moq.AutoMock;
using Moq;
using Application.Commons.Domain;
using Microsoft.Extensions.Logging;

namespace UnitTest.UseCases.ProcessReceipt.ReceiptProcessors;

public class ProcessReceiptTests: IClassFixture<ProcessReceiptFixture>
{
    private readonly IProcessReceiptUseCase _sut;
    private readonly Mock<IProcessReceiptOutputPort> _outputPort;

    public ProcessReceiptTests(ProcessReceiptFixture fixture)
    {
        var mocker = new AutoMocker();
        
        var logger = mocker.GetMock<ILogger<ProcessReceiptUseCase>>();
        var processFactory = fixture.GetProcessorFactory();

        _sut = new ProcessReceiptUseCase(processFactory, logger.Object);

        _outputPort = mocker.GetMock<IProcessReceiptOutputPort>();
        _sut.SetOutputPort(_outputPort.Object);
    }

    [Theory]
    [InlineData(ProductType.Fisical)]
    [InlineData(ProductType.Book)]
    [InlineData(ProductType.Video)]
    [InlineData(ProductType.Video, true)]
    public async Task ShouldProcessProductReceipt(ProductType productType, bool tutorialVideo = false)
    {
        // Arrange
        var receipt = new PaymentReceipt()
        {
            Product = new Product()
            {
                Type = productType,
                Video = tutorialVideo ? new() { TutorialVideo = new() } : null
            }
        };
        var input = new ProcessReceiptInput(receipt);

        // Act
        await _sut.Execute(input);

        // Assert
        _outputPort.Verify(output => output.Ok(), Times.Once);
    }

    [Theory]
    [InlineData(MembershipType.New)]
    [InlineData(MembershipType.Upgrade)]
    public async Task ShouldProcessMembershipReceipt(MembershipType membershipType)
    {
        // Arrange
        var receipt = new PaymentReceipt()
        {
            Membership = new Membership(),
            MembershipType = membershipType
        };
        var input = new ProcessReceiptInput(receipt);

        // Act
        await _sut.Execute(input);

        // Assert
        _outputPort.Verify(output => output.Ok(), Times.Once);
    }
}