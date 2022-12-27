using Application.Commons.MailSender;
using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.ReceiptProcessors;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.CommissionPaymentGenerator;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.CommissionPaymentGenerator.Abstractions;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.DeliveryNoteSender.Abstractions;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.Factories;
using Application.UseCases.ProcessReceipt.ReceiptProcessors.Factories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.ProcessReceipt;

public static class ProcessReceiptInstaller
{
    public static IServiceCollection AddProcessReceiptUseCase(this IServiceCollection services) =>
        services
            .AddSingleton<IProcessReceiptUseCase, ProcessReceiptUseCase>()
            .AddSingleton<IReceiptProcessorFactory, ReceiptProcessorFactory>()

            // Receipt Processors Interfaces
            .AddSingleton<IReceiptProcessor, FisicalProductProcessor>()
            .AddSingleton<IReceiptProcessor, BookProductProcessor>()
            .AddSingleton<IReceiptProcessor, VideoProductProcessor>()
            .AddSingleton<IReceiptProcessor, MembershipProcessor>()
            .AddSingleton<IReceiptProcessor, MembershipUpgradeProcessor>()
            .AddSingleton<IReceiptProcessor, DefaultReceiptProcessor>()

            // Default Processors Interfaces
            .AddSingleton<IDefaultReceiptProcessor, DefaultReceiptProcessor>()

            // Interfaces used by Processors
            .AddSingleton<IDeliveryNoteSender, DeliveryNoteSender>()
            .AddSingleton<ICommissionPaymentGenerator, CommissionPaymentGenerator>()
            .AddSingleton<IMailSender, MailSender>();
}
