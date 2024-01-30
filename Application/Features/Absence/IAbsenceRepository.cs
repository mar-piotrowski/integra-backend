using Application.Abstractions.Repositories;
using Domain.ValueObjects.Ids;

namespace Application.Features.Absence;

public interface IAbsenceRepository : IRepository<Domain.Entities.Absence, AbsenceId> {
    public IEnumerable<Domain.Entities.Absence> GetAll(UserId? userId);
    public Domain.Entities.Absence? GetByIdWithStatus(AbsenceId absenceId);
}