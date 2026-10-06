using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Application.Behaviors;

namespace ShopApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(IAssemblyMarker).Assembly;

        // mediatr
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        // fluentValidation
        services.AddValidatorsFromAssembly(assembly);
        // validation pipeline
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
