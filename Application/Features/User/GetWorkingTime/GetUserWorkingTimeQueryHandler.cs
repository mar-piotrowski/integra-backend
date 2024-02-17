using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.Mappers;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.User.GetWorkingTime;

public class GetUserWorkingTimeQueryHandler : IQueryHandler<GetUserWorkingTimeQuery, UserWorkingTimeResponse> {
    private readonly IUserRepository _userRepository;
    private readonly WorkingTimeMapper _workingTimeMapper;

    public GetUserWorkingTimeQueryHandler(IUserRepository userRepository, WorkingTimeMapper workingTimeMapper) {
        _userRepository = userRepository;
        _workingTimeMapper = workingTimeMapper;
    }

    public async Task<Result<UserWorkingTimeResponse>> Handle(
        GetUserWorkingTimeQuery request,
        CancellationToken cancellationToken
    ) {
        var user = _userRepository.FindById(request.UserId);
        return user is null
            ? Result.Failure<UserWorkingTimeResponse>(UserErrors.NotFound)
            : Result.Success(new UserWorkingTimeResponse(_workingTimeMapper.MapToDtos(user.WorkingTimes)));
    }
}