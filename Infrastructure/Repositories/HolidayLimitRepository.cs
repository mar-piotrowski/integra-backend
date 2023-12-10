using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HolidayLimitRepository : Repository<HolidayLimit, HolidayLimitId>, IHolidayLimitRepository {
    public HolidayLimitRepository(DatabaseContext dbContext) : base(dbContext) { }

    public HolidayLimit? GetByYear(DateTime start, DateTime end) =>
        DbContext.Set<HolidayLimit>()
            .FirstOrDefault(entry => entry.StartDate.Year == start.Year && entry.EndDate.Year == end.Year);

    public List<HolidayLimit> GetAll(UserId userId) {
        IQueryable<HolidayLimit> queryable = DbContext.Set<HolidayLimit>();
        if (userId.Value > 0)
            queryable = queryable
                .Include(holidayLimit => holidayLimit.User)
                .Where(entry => entry.UserId == userId);
        return queryable.ToList();
    }
}