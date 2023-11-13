using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IUserRepository : IRepository<User, UserId> {
    public User? GetByEmail(Email email);
    public User? GetByIdentityNumber(IdentityNumber identityNumber);
}