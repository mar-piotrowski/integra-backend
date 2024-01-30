using Application.Features.Absence;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AbsenceRepository : Repository<Absence, AbsenceId>, IAbsenceRepository {
    public AbsenceRepository(DatabaseContext dbContext) : base(dbContext) { }

    public IEnumerable<Absence> GetAll(UserId? userId) {
        IQueryable<Absence> queryable = DbContext.Set<Absence>().Include(u => u.User);
        if (userId is not null)
            queryable = queryable.Where(u => u.UserId == userId);
        return queryable.ToList();
    }

    public Absence? GetByIdWithStatus(AbsenceId absenceId) =>
        DbContext.Set<Absence>()
            .Include(u => u.User)
            .FirstOrDefault(entry => entry.Id == absenceId);
}