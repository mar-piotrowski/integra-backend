using Application.Dtos;
using Domain.Entities;

namespace Application.Abstractions.Services;

public interface IScheduleService {
    public UserScheduleDto CreateUserSchedule(User user, int year, int month, bool onlyWeek);

    public List<UserScheduleDto> CreateUsersSchedule(IEnumerable<User> users, int year, int month, bool onlyWeek);
}