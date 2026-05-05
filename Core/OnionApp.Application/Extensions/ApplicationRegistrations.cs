

using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace OnionApp.Application.Extensions
{
    public static class ApplicationRegistrations
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(ApplicationAssembly).Assembly);
            });


            services.AddSingleton(TypeAdapterConfig.GlobalSettings);
            services.AddValidatorsFromAssembly(typeof(ApplicationAssembly).Assembly); services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            return services;

        }

    }
}