using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class ContractChange : Entity<ContractChangeId> {
    public ContractId ContractId { get; private set; }
    public ContractId ContractChangeId { get; private set; }
    public virtual Contract Contract { get; private set; }
    public virtual Contract ContractChanged { get; private set; }

    public ContractChange() { }

    public ContractChange(ContractId contractId, ContractId contractChangeId) {
        ContractId = contractId;
        ContractChangeId = contractChangeId;
    }
}