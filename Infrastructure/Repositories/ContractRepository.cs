using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Infrastructure.Repositories;

public class ContractRepository : Repository<Contract, ContractId> , IContractRepository{
    public ContractRepository(DatabaseContext dbContext) : base(dbContext) { }
    
    public Contract? FindByUser(ContractType? contractType) {
        throw new NotImplementedException();
    }
}