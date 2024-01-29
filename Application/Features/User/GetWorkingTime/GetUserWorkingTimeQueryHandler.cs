using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Common.Errors;
using Domain.Common.Result;

namespace Application.Features.User.GetWorkingTime;

public class GetUserWorkingTimeQueryHandler : IQueryHandler<GetUserWorkingTimeQuery, UserWorkingTimeResponse> {
    private readonly IUserRepository _userRepository;

    public GetUserWorkingTimeQueryHandler(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public async Task<Result<UserWorkingTimeResponse>> Handle(
        GetUserWorkingTimeQuery request,
        CancellationToken cancellationToken
    ) {
        var user = _userRepository.WorkingHours(request.UserId);
        if (user is null)
            return Result.Failure<UserWorkingTimeResponse>(UserErrors.NotFound);
        return Result.Success(new UserWorkingTimeResponse());
    }
}