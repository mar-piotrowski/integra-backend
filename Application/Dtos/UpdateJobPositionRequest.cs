using Domain.ValueObjects.Ids;

namespace Application.Dtos;

public record UpdateJobPositionRequest(JobPositionId JobId, string Title);
    