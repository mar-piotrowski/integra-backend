using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ContractRepository : Repository<Contract, ContractId>, IContractRepository {
    public ContractRepository(DatabaseContext dbContext) : base(dbContext) { }

    public IEnumerable<Contract> GetAll(ContractQueries queries) {
        IQueryable<Contract> query = DbContext.Set<Contract>()
            .Include(u => u.User)
            .Where(contract =>
                contract.ContractType == ContractType.ManageContract
                || contract.ContractType == ContractType.EmploymentContract
                || contract.ContractType == ContractType.ForWorkContract
                || contract.ContractType == ContractType.MandateContract
                || contract.ContractType == ContractType.None
            );
        if (queries.ContractType != ContractType.None)
            query = query.Where(contract => contract.ContractType == queries.ContractType);
        if (queries.UserId is not -1)
            query = query.Where(contract => contract.UserId == UserId.Create(queries.UserId));
        return query.ToList();
    }

    public override Contract? FindById(ContractId contractId) =>
        DbContext.Set<Contract>()
            .Include(u => u.User)
            .FirstOrDefault(contract => contract.Id == contractId);
}