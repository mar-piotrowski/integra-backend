using Application.Abstractions.Repositories;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence;

public interface IAbsenceRepository : IRepository<Domain.Entities.Absence, AbsenceId> {
    public IEnumerable<Domain.Entities.Absence> GetAllWithUser();
    public Domain.Entities.Absence? GetByIdWithStatus(AbsenceId absenceId);
}