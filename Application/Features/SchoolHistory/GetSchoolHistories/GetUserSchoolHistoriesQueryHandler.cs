using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.SchoolHistory.GetSchoolHistories;

public class GetUserSchoolHistoriesQueryHandler : IQueryHandler<GetUserSchoolHistoriesQuery, List<SchoolHistoryDto>> {
    private readonly ISchoolHistoryRepository _schoolHistoryRepository;
    private readonly IUserRepository _userRepository;

    public GetUserSchoolHistoriesQueryHandler(
        ISchoolHistoryRepository schoolHistoryRepository,
        IUserRepository userRepository
    ) {
        _schoolHistoryRepository = schoolHistoryRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<List<SchoolHistoryDto>>> Handle(
        GetUserSchoolHistoriesQuery request,
        CancellationToken cancellationToken
    ) {
        if (request.UserId.Value > 0 && _userRepository.GetById(request.UserId) is null)
            return Result.Failure<List<SchoolHistoryDto>>(UserErrors.NotFound);
        var schoolHistories = await _schoolHistoryRepository.GetAll(request.UserId);
        return !schoolHistories.Any()
            ? Result.Failure<List<SchoolHistoryDto>>(SchoolHistoryErrors.NotFound)
            : Result.Success(schoolHistories.MapToDtos());
    }
}