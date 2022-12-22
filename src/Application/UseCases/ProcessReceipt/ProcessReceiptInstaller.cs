using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.ProcessReceipt;

public static class ProcessReceiptInstaller
{
    public static IServiceCollection AddProcessReceiptUseCase(this IServiceCollection services) =>
        services
            .AddSingleton<ProcessReceiptUseCase, ProcessReceiptUseCase>();
}
