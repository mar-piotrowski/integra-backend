using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.Features.Absence;
using Infrastructure.Authentication;
using Infrastructure.Interceptors;
using Infrastructure.Repositories;
using Infrastructure.Seeders;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    ) {
        services.AddDbContext<DatabaseContext>(
            options => {
                options.UseNpgsql(configuration.GetConnectionString("Database")).UseSnakeCaseNamingConvention();
            });
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.AddSingleton<PublishDomainEventsInterceptor>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
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
        services.AddScoped<IContractChangesRepository, ContractChangeRepository>();
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IUserPermissionsRepository, UserPermissionsRepository>();
        return services;
    }

    public static WebApplication SeedDatabase(this WebApplication app) {
        using (var scope = app.Services.CreateScope()) {
            var context = scope.ServiceProvider.GetService<DatabaseContext>();
            new Seeder(context!).Seed();
        }

        return app;
    }
}