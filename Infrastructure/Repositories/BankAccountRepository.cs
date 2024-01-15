using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Infrastructure.Repositories;

public class BankAccountRepository : Repository<BankAccount, BankAccountId>, IBankAccountRepository {
    public BankAccountRepository(DatabaseContext dbContext) : base(dbContext) { }
}