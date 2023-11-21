using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AbsenceRepository : Repository<Absence, AbsenceId>, IAbsenceRepository {
    public AbsenceRepository(DatabaseContext dbContext) : base(dbContext) { }

    public IEnumerable<Absence> GetAllWithUser() =>
        DbContext.Absences.Include(u => u.User).Include(s => s.Status).ToList();

    public Absence? GetByIdWithStatus(AbsenceId absenceId) =>
        DbContext.Absences.Include(u => u.User).Include(s => s.Status).FirstOrDefault(entry => entry.Id == absenceId);
}