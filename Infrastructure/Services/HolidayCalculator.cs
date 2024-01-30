using Application.Abstractions;
using Application.Abstractions.Repositories;
using Domain.Common.Errors;
using Domain.Common.Models;
using Domain.Common.Result;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Infrastructure.Services;

public class HolidayCalculator : IHolidayCalculator {
    private readonly IUserRepository _userRepository;

    public HolidayCalculator(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    public Result<CalculatedHolidayLimit> CalculateLimit(UserId userId, DateTime start, DateTime end) {
        var user = _userRepository.GetInfoToCreateLimit(userId);
        if (user is null)
            return Result.Failure<CalculatedHolidayLimit>(UserErrors.NotFound);
        var userLimits = user.HolidayLimits
            .FirstOrDefault(limit => limit.StartDate.AddYears(-1) == start);
        var contractWorkingTime = user.Contracts.FirstOrDefault(contract => contract.Status == ContractStatus.Active);
        if (contractWorkingTime is null)
            return Result.Failure<CalculatedHolidayLimit>(ContractsErrors.NonActiveContract);
        var limit = CalculateLimitViaEducationDegree(user.SchoolHistories.ToList())
                    + CalculateLimitViaWorkYears(user.JobHistories.ToList());
        return userLimits is null
            ? Result.Success(new CalculatedHolidayLimit(ChooseLimit(limit), 0))
            : Result.Success(new CalculatedHolidayLimit(ChooseLimit(limit) + userLimits.AvailableDays,
                userLimits.AvailableDays));
    }

    private static int CalculateLimitViaEducationDegree(IReadOnlyCollection<SchoolHistory> schoolHistories) {
        if (!schoolHistories.Any())
            return 0;
        return schoolHistories.Aggregate(0, (current, userEducation) => userEducation.Degree switch {
            SchoolDegree.PrimaryEducation => 3,
            SchoolDegree.VocationalEducation => 5,
            SchoolDegree.SecondaryGeneralEducation => 4,
            SchoolDegree.PostSecondaryEducation => 6,
            SchoolDegree.HigherEducation => 8,
            _ => current
        });
    }

    private static int CalculateLimitViaWorkYears(IReadOnlyCollection<JobHistory> jobHistories) {
        if (!jobHistories.Any())
            return 0;
        return (int)jobHistories.Select(jobHistory => (jobHistory.EndDate - jobHistory.StartDate).TotalDays / 365)
            .Aggregate<double, decimal>(0, (current, days) => current + (int)Math.Floor(Math.Round(days)));
    }

    private static int ChooseLimit(int limit) => limit >= 10 ? 26 : 20;
}