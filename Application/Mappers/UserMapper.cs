using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class UserMapper {
    public static UserDto MapToDto(this User user) => new UserDto() {
        Id = user.Id.Value,
        Firstname = user.Firstname,
        SecondName = user.SecondName,
        Lastname = user.Lastname,
        Email = user.Email.Value,
        Phone = user.Phone,
        DateOfBirth = user.DateOfBirth,
        PlaceOfBirth = user.PlaceOfBirth,
        IsStudent = user.IsStudent,
        Sex = user.Sex,
        IdentityNumber = user.IdentityNumber,
        JobPosition = user.JobPosition?.Title,
        Locations = user.Locations.MapToDtos().ToList()
    };

    public static UsersResponse MapToUsersResponse(this IEnumerable<User> users) =>
        new UsersResponse(users.Select(user => user.MapToDto()));
}