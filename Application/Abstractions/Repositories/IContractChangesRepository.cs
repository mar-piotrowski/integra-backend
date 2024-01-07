using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IContractChangesRepository : IRepository<ContractChange, ContractChangeId> {
    public IEnumerable<Contract>? GetChangesForContract(ContractId contractId);
} 