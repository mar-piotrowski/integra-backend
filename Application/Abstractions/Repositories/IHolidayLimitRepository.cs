using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IHolidayLimitRepository : IRepository<HolidayLimit, HolidayLimitId> {
    public HolidayLimit? GetByYear(DateTime start, DateTime end);
    public List<HolidayLimit> GetAll(UserId userId);
}