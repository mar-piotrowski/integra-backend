using Application.Abstractions;
using Application.Abstractions.Repositories;
using Infrastructure.Authentication;
using Infrastructure.Interceptors;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<DatabaseContext>(
            options => {
                options.UseNpgsql(configuration.GetConnectionString("Database")).UseSnakeCaseNamingConvention();
            });
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
        services.AddScoped<IJobHistoryRepository, JobHistoryRepository>();
        services.AddScoped<ISchoolHistoryRepository, SchoolHistoryRepository>();
        services.AddScoped<IHolidayLimitRepository, HolidayLimitRepository>();
        services.AddScoped<IHolidayCalculator, HolidayCalculator>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}