using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ContractorRepository : Repository<Contractor, ContractorId>, IContractorRepository {
    public ContractorRepository(DatabaseContext dbContext) : base(dbContext) { }

    public IEnumerable<Contractor> GetAllWithLocation() =>
        DbContext.Set<Contractor>().Include(p => p.Location).Include(b => b.BankAccount).ToList();

    public Contractor? FindByNip(Nip nip) =>
        DbContext.Set<Contractor>()
            .Include(l => l.Location)
            .Include(b => b.BankAccount)
            .FirstOrDefault(entry => entry.Nip == nip);
}