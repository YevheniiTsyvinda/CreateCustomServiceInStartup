using Microsoft.Extensions.DependencyInjection;

public static class ServiceProviderExtensions{
    public static void AddTimeService(this IServiceCollection services){
        services.AddTransient<TimeService>();
    }
}