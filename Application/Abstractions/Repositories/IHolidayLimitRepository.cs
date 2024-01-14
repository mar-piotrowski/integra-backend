using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IHolidayLimitRepository : IRepository<HolidayLimit, HolidayLimitId> {
    public List<HolidayLimit> GetAll(UserId userId);
}