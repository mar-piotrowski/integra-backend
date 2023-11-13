using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Infrastructure.Repositories;

public sealed class UserRepository : Repository<User, UserId>, IUserRepository {
    public UserRepository(DatabaseContext dbContext) : base(dbContext) { }

    public User? GetByEmail(Email email) =>
        DbContext.Set<User>().FirstOrDefault(user => user.Email == email);

    public User? GetByIdentityNumber(IdentityNumber identityNumber) =>
        DbContext.Set<User>().FirstOrDefault(user => user.IdentityNumber == identityNumber);
}