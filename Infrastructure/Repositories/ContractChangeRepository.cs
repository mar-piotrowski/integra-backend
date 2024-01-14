using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ContractChangeRepository : Repository<ContractChange, ContractChangeId>, IContractChangesRepository {
    public ContractChangeRepository(DatabaseContext dbContext) : base(dbContext) { }
    
    public IEnumerable<Contract>? GetChangesForContract(ContractId contractId) {
        var changes = DbContext.Set<ContractChange>()
            .Where(contract => contract.ContractId == contractId)
            .Include(c => c.Contract)
            .Include(c => c.ContractChanged)
            .ToList();
        if (!changes.Any())
            return null;
        return changes
            .Select(contractChange =>
                DbContext.Set<Contract>().FirstOrDefault(c => c.Id == contractChange.ContractChangeId))
            .OfType<Contract>().ToList();
    }
}