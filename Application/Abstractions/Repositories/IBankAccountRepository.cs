using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IBankAccountRepository : IRepository<BankAccount, BankAccountId> { }