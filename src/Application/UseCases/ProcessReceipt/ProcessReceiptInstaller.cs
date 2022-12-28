using Application.Commons.MailSender;
using Application.Commons.MailSender.Abstractions;
using Application.UseCases.ProcessReceipt.Abstractions;
using Application.UseCases.ProcessReceipt.Processors;
using Application.UseCases.ProcessReceipt.Processors.CommissionPaymentGenerator;
using Application.UseCases.ProcessReceipt.Processors.CommissionPaymentGenerator.Abstractions;
using Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender;
using Application.UseCases.ProcessReceipt.Processors.DeliveryNoteSender.Abstractions;
using Application.UseCases.ProcessReceipt.Processors.Factories;
using Application.UseCases.ProcessReceipt.Processors.Factories.Abstractions;
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
