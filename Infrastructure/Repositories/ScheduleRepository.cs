using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ScheduleRepository : Repository<ScheduleSchema, ScheduleSchemaId>, IScheduleRepository {
    public ScheduleRepository(DatabaseContext dbContext) : base(dbContext) { }

    public override IEnumerable<ScheduleSchema> FindAll() =>
        DbContext.Set<ScheduleSchema>().Include(d => d.Days).ToList();

    public override ScheduleSchema? FindById(ScheduleSchemaId id) =>
        DbContext.Set<ScheduleSchema>().Include(d => d.Days).FirstOrDefault(schema => schema.Id == id);
    
    public ScheduleSchema? FindByName(string name) =>
        DbContext.Set<ScheduleSchema>().FirstOrDefault(schedule => schedule.Name == name);
}