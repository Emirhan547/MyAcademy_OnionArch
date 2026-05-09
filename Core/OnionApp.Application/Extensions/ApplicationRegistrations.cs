using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionApp.Application;
using OnionApp.Application.Behaviors;
using OnionApp.Domain.Entities;
using System.Reflection;

namespace OnionApp.Application.Extensions;

public static class ApplicationRegistrations
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(ApplicationAssembly).Assembly);
        });

        
        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLoggingBehavior<,>));
services.AddValidatorsFromAssembly(typeof(ApplicationAssembly).Assembly);
services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

return services;
    }
}
