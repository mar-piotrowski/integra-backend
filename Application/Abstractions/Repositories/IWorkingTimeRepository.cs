using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IWorkingTimeRepository : IRepository<WorkingTime, WorkingTimeId> {
    public IEnumerable<WorkingTime> FindAll(UserId? userId);
}