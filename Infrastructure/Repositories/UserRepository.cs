using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class UserRepository : Repository<User, UserId>, IUserRepository {
    public UserRepository(DatabaseContext dbContext) : base(dbContext) { }

    public override User? GetById(UserId userId) =>
        DbContext.Set<User>()
            .Include(l => l.Locations)
            .Include(j => j.JobPosition)
            .Include(c => c.Credential)
            .Include(p => p.Permissions).ThenInclude(p => p.Permission)
            .FirstOrDefault(entry => entry.Id == userId);

    public override IEnumerable<User> GetAll() =>
        DbContext.Set<User>()
            .Include(l => l.Locations)
            .Include(j => j.JobPosition)
            .Include(p => p.Permissions).ThenInclude(p => p.Permission);

    public IEnumerable<User> GetAllWithPosition(string position) =>
        DbContext.Set<User>()
            .Where(user => user.JobPosition != null && user.JobPosition.Title == position);

    public IEnumerable<User> GetAllWithLocation() =>
        DbContext.Set<User>()
            .Include(l => l.Locations)
            .Include(j => j.JobPosition);

    public User? GetByEmail(Email email) =>
        DbContext.Set<User>()
            .Include(c => c.Credential)
            .FirstOrDefault(user => user.Email == email);

    public User? GetByIdentityNumber(IdentityNumber identityNumber) =>
        DbContext.Set<User>()
            .Include(l => l.Locations)
            .Include(j => j.JobPosition)
            .FirstOrDefault(user => user.IdentityNumber == identityNumber);
}