using Application.Abstractions;
using Application.Abstractions.Repositories;
using Domain.Common.Models;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Infrastructure.Services;

public class HolidayCalculator : IHolidayCalculator {
    private readonly IHolidayLimitRepository _holidayLimitRepository;
    private readonly IJobHistoryRepository _jobHistoryRepository;
    private readonly ISchoolHistoryRepository _historyRepository;

    public HolidayCalculator(
        IJobHistoryRepository jobHistoryRepository,
        ISchoolHistoryRepository historyRepository,
        IHolidayLimitRepository holidayLimitRepository
    ) {
        _jobHistoryRepository = jobHistoryRepository;
        _historyRepository = historyRepository;
        _holidayLimitRepository = holidayLimitRepository;
    }

    public CalculatedHolidayLimit CalculateLimit(UserId userId, DateTime start, DateTime end) {
        var previousYear = _holidayLimitRepository.GetByYear(start.AddYears(-1), end.AddYears(-1));
        var limit = CalculateLimitViaEducationDegree(userId) + CalculateLimitViaWorkYears(userId);
        return previousYear is null
            ? new CalculatedHolidayLimit(ChooseLimit(limit), 0)
            : new CalculatedHolidayLimit(ChooseLimit(limit) + previousYear.AvailableDays, previousYear.AvailableDays);
    }

    private int CalculateLimitViaEducationDegree(UserId userId) {
        // var userEducations = _historyRepository.GetAll(userId);
        // if (!userEducations.Any())
        //     return 0;
        // var limit = 0;
        // foreach (var userEducation in userEducations) {
        //     switch (userEducation.Degree) {
        //         case SchoolDegree.PrimaryEducation:
        //             limit = 3;
        //             break;
        //         case SchoolDegree.VocationalEducation:
        //             limit = 5;
        //             break;
        //         case SchoolDegree.SecondaryGeneralEducation:
        //             limit = 4;
        //             break;
        //         case SchoolDegree.PostSecondaryEducation:
        //             limit = 6;
        //             break;
        //         case SchoolDegree.HigherEducation:
        //             limit = 8;
        //             break;
        //     }
        // }

        // return limit;
        return 0;
    }

    private int CalculateLimitViaWorkYears(UserId userId) {
        // var userJobs = _jobHistoryRepository.GetAll(userId);
        // if (!userJobs.Any())
        //     return 0;
        // decimal limit = 0;
        // foreach (var jobHistory in userJobs) {
        //     var days = (jobHistory.EndDate - jobHistory.StartDate).TotalDays / 365;
        //     limit += (int)Math.Floor(Math.Round(days));
        // }
        //
        // return (int)limit;
        return 0;
    }

    private int ChooseLimit(int limit) => limit >= 10 ? 26 : 20;
}