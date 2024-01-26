using Domain.Common.Models;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Infrastructure.Interceptors;
using Infrastructure.Seeders;
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
    public DbSet<BankAccount> BankAccounts { get; init; }
    public DbSet<WorkingTime> WorkingTimes { get; init; }
    public DbSet<UserWorkingTimes> UserWorkingTimes { get; init; }
    public DbSet<ScheduleSchema> ScheduleSchemas { get; init; }
    public DbSet<ScheduleSchemaDay> ScheduleSchemaDays { get; init; }

    public DatabaseContext(
        DbContextOptions<DatabaseContext> options,
        PublishDomainEventsInterceptor domainEventsInterceptor
    ) : base(options) {
        _domainEventsInterceptor = domainEventsInterceptor;
    }

    static DatabaseContext() {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Ignore<List<IDomainEvent>>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.AddInterceptors(_domainEventsInterceptor);
    }
}