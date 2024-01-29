using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions.Repositories;

public interface IScheduleRepository : IRepository<ScheduleSchema, ScheduleSchemaId> {
    public ScheduleSchema? FindByName(string name);
}