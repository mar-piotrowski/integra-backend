using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IUserRepository : IRepository<User, UserId> {
    public IEnumerable<User> GetAllWithPosition(string position);
    public IEnumerable<User> GetAllWithLocation();
    public User? GetByEmail(Email email);
    public User? GetByPersonalIdNumber(PersonalIdNumber personalIdNumber);
    public User? GetInfoToCreateLimit(UserId userId);
    public User? WorkingHours(UserId userId);
    public User? FindUserSchedules(UserId userId);
    public List<User> FindUsersWithSchedule();
}