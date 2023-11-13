using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IContractorRepository : IRepository<Contractor, ContractorId> {
    public Contractor? FindByNip(Nip nip);
    public IEnumerable<Contractor> GetAllWithLocation();
}