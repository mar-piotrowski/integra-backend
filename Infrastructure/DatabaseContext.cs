using Domain.Common.Models;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DatabaseContext : DbContext {
    private readonly PublishDomainEventsInterceptor _domainEventsInterceptor;

    public DbSet<User> Users { get; init; }
    public DbSet<Contractor> Contractors { get; init; }
    public DbSet<Article> Articles { get; init; }
    public DbSet<Credential> Credentials { get; init; }
    public DbSet<Stock> Stocks { get; init; }
    public DbSet<Location> Locations { get; init; }
    public DbSet<Contract> Contracts { get; init; }
    public DbSet<InsuranceCode> InsuranceCodes { get; init; }
    public DbSet<JobPosition> JobPositions { get; init; }
    public DbSet<JobHistory> JobHistories { get; init; }
    public DbSet<SchoolHistory> SchoolHistories { get; init; }
    public DbSet<HolidayLimit> HolidayLimits { get; init; }
    public DbSet<Absence> Absences { get; init; }
    public DbSet<Card> Cards { get; init; }
    public DbSet<Permission> Permissions { get; init; }
    public DbSet<UserPermissions> UserPermissions { get; init; }
    
    public DatabaseContext(
        DbContextOptions<DatabaseContext> options,
        PublishDomainEventsInterceptor domainEventsInterceptor
    ) : base(options) {
        _domainEventsInterceptor = domainEventsInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Ignore<List<IDomainEvent>>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.AddInterceptors(_domainEventsInterceptor);
    }
}