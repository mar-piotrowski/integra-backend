using Application.Abstractions;
using Application.Abstractions.Repositories;
using Infrastructure.Authentication;
using Infrastructure.Interceptors;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddEntityFrameworkNpgsql();
        services.AddSingleton<DatabaseContext>();
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.AddSingleton<PublishDomainEventsInterceptor>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IContractorRepository, ContractorRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<IContractRepository, ContractRepository>();
        services.AddScoped<IJobPositionRepository, JobPositionRepository>();
        services.AddScoped<IAbsenceRepository, AbsenceRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}