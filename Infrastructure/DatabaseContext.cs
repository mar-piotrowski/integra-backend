using Domain.Common.Models;
using Domain.Entities;
using Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public class DatabaseContext : DbContext {
    private readonly PublishDomainEventsInterceptor _domainEventsInterceptor;
    private readonly IConfiguration _configuration;
    private const string ConnectionName = "Database";

    public DbSet<User> Users { get; set; }
    public DbSet<Contractor> Contractors { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Credential> Credentials { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<InsuranceCode> InsuranceCodes { get; set; }
    public DbSet<JobPosition> JobPositions { get; set; }

    public DatabaseContext(IConfiguration configuration, PublishDomainEventsInterceptor domainEventsInterceptor) {
        _configuration = configuration;
        _domainEventsInterceptor = domainEventsInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Ignore<List<IDomainEvent>>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString(ConnectionName));
        optionsBuilder.AddInterceptors(_domainEventsInterceptor);
    }
}