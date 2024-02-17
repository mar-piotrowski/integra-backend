using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class UserRepository : Repository<User, UserId>, IUserRepository {
    public UserRepository(DatabaseContext dbContext) : base(dbContext) { }

    public override User? FindById(UserId userId) =>
        DbContext.Set<User>()
            .Where(u => u.Active)
            .Include(l => l.Locations)
            .Include(j => j.JobPosition)
            .Include(c => c.Credential)
            .Include(b => b.BankAccount)
            .Include(c => c.Contracts)
            .Include(p => p.Permissions).ThenInclude(p => p.Permission)
            .FirstOrDefault(entry => entry.Id == userId);

    public override IEnumerable<User> FindAll() =>
        DbContext.Set<User>()
            .Where(u => u.Active)
            .Include(l => l.Locations)
            .Include(j => j.JobPosition)
            .Include(b => b.BankAccount)
            .Include(p => p.Permissions).ThenInclude(p => p.Permission)
            .ToList();

    public IEnumerable<User> GetAllWithPosition(string position) =>
        DbContext.Set<User>()
            .Where(u => u.Active)
            .Where(user => user.JobPosition != null && user.JobPosition.Title == position);

    public IEnumerable<User> GetAllWithLocation() =>
        DbContext.Set<User>()
            .Where(u => u.Active)
            .Include(l => l.Locations)
            .Include(j => j.JobPosition);

    public User? FindWithAbsences(UserId userId) =>
        DbContext.Set<User>()
            .Where(u => u.Active)
            .Include(a => a.Absences)
            .Include(l => l.HolidayLimits)
            .FirstOrDefault(u => u.Id == userId);

    public User? GetByEmail(Email email) =>
        DbContext.Set<User>()
            .Where(u => u.Active)
            .Include(c => c.Credential)
            .Include(p => p.Permissions).ThenInclude(p => p.Permission)
            .FirstOrDefault(user => user.Email == email);

    public User? GetByPersonalIdNumber(PersonalIdNumber personalIdNumber) =>
        DbContext.Set<User>()
            .Where(u => u.Active)
            .Include(l => l.Locations)
            .Include(j => j.JobPosition)
            .FirstOrDefault(user => user.PersonalIdNumber == personalIdNumber);

    public User? GetInfoToCreateLimit(UserId userId) =>
        DbContext.Set<User>()
            .Where(u => u.Active)
            .Include(c => c.Contracts)
            .Include(h => h.HolidayLimits)
            .Include(s => s.SchoolHistories)
            .Include(j => j.JobHistories)
            .FirstOrDefault(entry => entry.Id == userId);

    public User? FindUserSchedules(UserId userId) =>
        DbContext.Set<User>()
            .Where(u => u.Active)
            .Include(s => s.Schedules)
            .ThenInclude(s => s.ScheduleSchema)
            .ThenInclude(s => s.Days)
            .FirstOrDefault(u => u.Id == userId);

    public List<User> FindUsersWithSchedule() =>
        DbContext.Set<User>()
            .Where(u => u.Active)
            .Include(s => s.Schedules)
            .ThenInclude(s => s.ScheduleSchema)
            .ThenInclude(s => s.Days)
            .ToList();

    public User? FindWorkingTimes(UserId userId) =>
        DbContext.Set<User>()
            .Include(w => w.WorkingTimes)
            .FirstOrDefault(u => u.Id == userId);
}