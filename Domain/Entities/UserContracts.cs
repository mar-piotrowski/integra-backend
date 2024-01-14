using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public class UserContracts : Entity<UserContractsId> {
    public UserId UserId { get; private set; }
    public ContractId ContractId { get; private set; }
    public User User { get; private set; }
    public Contract Contract { get; private set; }

    public UserContracts(UserId userId, ContractId contractId) {
        UserId = userId;
        ContractId = contractId;
    }
}