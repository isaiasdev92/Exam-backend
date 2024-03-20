using Microsoft.Extensions.DependencyInjection;

namespace CleanTemplate.Transversal.Core;

public static class TransversalServiceRegistration
{
    public static IServiceCollection AddTransversalServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}
