using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IJobHistoryRepository : IRepository<JobHistory, JobHistoryId> {
    public Task<List<JobHistory>> GetAll(UserId userId);
}