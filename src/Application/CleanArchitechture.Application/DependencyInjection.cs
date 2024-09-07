using CleanArchitechture.Application.Abstraction;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitechture.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var currentAssemply = typeof(DependencyInjection).Assembly;
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(currentAssemply);

                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
            services.AddValidatorsFromAssembly(currentAssemply);
            services.AddAutoMapper(config =>
            {
                config.AddMaps(currentAssemply);
            });

            return services;
        }
    }
}
