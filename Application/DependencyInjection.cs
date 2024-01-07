using System.Reflection;
using Application.Dtos;
using Application.Mappers;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection {
    private static readonly Assembly Assembly = typeof(DependencyInjection).Assembly;
    
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly));
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<ContractMapper>();
        services.AddScoped<UserMapper>();
        services.AddScoped<JobPositionMapper>();
        services.AddValidatorsFromAssembly(Assembly);
        return services;
    }
}