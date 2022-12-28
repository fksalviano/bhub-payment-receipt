using Application.UseCases.ProcessReceipt;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Commons.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services) =>
        services.AddProcessReceiptUseCase();
}