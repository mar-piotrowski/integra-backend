using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SchoolHistoryRepository : Repository<SchoolHistory, SchoolHistoryId>, ISchoolHistoryRepository {
    public SchoolHistoryRepository(DatabaseContext dbContext) : base(dbContext) { }

    public async Task<List<SchoolHistory>> GetAll(UserId userId) {
        IQueryable<SchoolHistory> queryable = DbContext.Set<SchoolHistory>();
        if (userId.Value > 0)
            queryable = queryable
                .Include(u => u.User)
                .Where(schoolHistory => schoolHistory.UserId == userId);
        return await queryable.ToListAsync();
    }

    public void UpdateById(SchoolHistoryId schoolHistoryId, SchoolHistory schoolHistory) =>
        DbContext.Set<SchoolHistory>().FirstOrDefault(entry => entry.Id == schoolHistoryId)?.Update(schoolHistory);
}