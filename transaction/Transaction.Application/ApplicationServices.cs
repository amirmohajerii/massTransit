using Microsoft.Extensions.DependencyInjection;
using System;

namespace Transaction.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServices).Assembly));
        return services;
    }
}
