using Microsoft.Extensions.DependencyInjection;
using System;

namespace Customer.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServices).Assembly));
        return services;
    }
}
