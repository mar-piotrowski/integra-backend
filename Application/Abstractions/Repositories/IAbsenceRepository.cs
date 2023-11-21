using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IAbsenceRepository : IRepository<Absence, AbsenceId> {
    public IEnumerable<Absence> GetAllWithUser();
    public Absence? GetByIdWithStatus(AbsenceId absenceId);
}