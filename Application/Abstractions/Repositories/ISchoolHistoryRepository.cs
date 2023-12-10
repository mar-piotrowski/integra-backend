using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface ISchoolHistoryRepository : IRepository<SchoolHistory, SchoolHistoryId> {
    public Task<List<SchoolHistory>> GetAll(UserId userId);
    public void UpdateById(SchoolHistoryId schoolHistoryId, SchoolHistory schoolHistory);
}