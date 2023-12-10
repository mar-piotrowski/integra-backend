using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class JobHistoryRepository : Repository<JobHistory, JobHistoryId>, IJobHistoryRepository {
    public JobHistoryRepository(DatabaseContext dbContext) : base(dbContext) { }

    public async Task<List<JobHistory>> GetAll(UserId userId) {
        IQueryable<JobHistory> queryable = DbContext.Set<JobHistory>();
        if (userId.Value > 0)
            queryable = queryable
                .Include(u => u.User)
                .Where(jobHistory => jobHistory.UserId == userId);
        return await queryable.ToListAsync();
    }
}