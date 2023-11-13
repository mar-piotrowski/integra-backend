using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IContractRepository : IRepository<Contract, ContractId> {
    public Contract? FindByUser(ContractType? contractType);
}