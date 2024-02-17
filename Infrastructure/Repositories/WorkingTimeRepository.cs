using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WorkingTimeRepository : Repository<WorkingTime, WorkingTimeId>, IWorkingTimeRepository {
    public WorkingTimeRepository(DatabaseContext dbContext) : base(dbContext) { }

    public IEnumerable<WorkingTime> FindAll(UserId? userId) {
        IQueryable<WorkingTime> queryable = DbContext.Set<WorkingTime>()
            .Include(u => u.User).ThenInclude(w => w.WorkingTimes);
        if (userId is not null)
            queryable = queryable.Where(u => u.UserId == userId);
        return queryable.ToList();
    }
}