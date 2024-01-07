using Application.Dtos;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IContractRepository : IRepository<Contract, ContractId> {
    public IEnumerable<Contract> GetAll(ContractQueries queries);
}