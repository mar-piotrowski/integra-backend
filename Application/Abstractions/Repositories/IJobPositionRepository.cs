using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IJobPositionRepository : IRepository<JobPosition, JobPositionId> {
    public JobPosition? GetByTitle(string title);
}