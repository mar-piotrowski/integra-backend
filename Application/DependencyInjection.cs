using System.Reflection;
using Application.Dtos;
using Application.Features.Document.Documents;
using Application.Features.Document.Documents.Invoice;
using Application.Features.Document.Documents.Mm;
using Application.Features.Document.Documents.Pw;
using Application.Features.Document.Documents.Pz;
using Application.Features.Document.Documents.Rw;
using Application.Features.Document.Documents.Wz;
using Application.Features.Permission;
using Application.Mappers;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Application;

public static class DependencyInjection {
    private static readonly Assembly Assembly = typeof(DependencyInjection).Assembly;

    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration) {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly));
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<ContractMapper>();
        services.AddScoped<UserMapper>();
        services.AddScoped<AbsenceMapper>();
        services.AddScoped<JobPositionMapper>();
        services.AddScoped<ScheduleMapper>();
        services.AddScoped<DocumentMapper>();
        services.AddScoped<StockMapper>();
        services.AddScoped<ContractorMapper>();
        services.AddScoped<WorkingTimeMapper>();
        services.AddScoped<IDocumentFactory, DocumentFactory>();
        services.AddScoped<DocumentInvoice>();
        services.AddScoped<DocumentMm>();
        services.AddScoped<DocumentPw>();
        services.AddScoped<DocumentPz>();
        services.AddScoped<DocumentRw>();
        services.AddScoped<DocumentWz>();
        services.AddValidatorsFromAssembly(Assembly);
        return services;
    }
}