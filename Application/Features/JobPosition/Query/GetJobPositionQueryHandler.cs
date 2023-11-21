using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Result;

namespace Application.Features.JobPosition.Query; 

public class GetJobPositionQueryHandler : IQueryHandler<GetJobPositionQuery, JobPositionDto> {
    private readonly IJobPositionRepository _jobPositionRepository;

    public GetJobPositionQueryHandler(IJobPositionRepository jobPositionRepository) {
        _jobPositionRepository = jobPositionRepository;
    }
    
    public async Task<Result<JobPositionDto>> Handle(GetJobPositionQuery request, CancellationToken cancellationToken) {
        var jobPosition = _jobPositionRepository.GetById(request.JobPositionId);
        if (jobPosition is null)
            return Result.Failure<JobPositionDto>(JobPositionErrors.TitleDoesNotExists);
        return Result.Success(new JobPositionDto(jobPosition.Title));
    }
}