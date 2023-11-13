using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Infrastructure.Repositories;

public class JobPositionRepository : Repository<JobPosition, JobPositionId>, IJobPositionRepository {
    public JobPositionRepository(DatabaseContext dbContext) : base(dbContext) { }

    public JobPosition? GetByTitle(string title) =>
        DbContext.Set<JobPosition>().FirstOrDefault(entry => entry.Title == title);
}