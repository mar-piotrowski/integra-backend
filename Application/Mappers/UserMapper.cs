using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class UserMapper {
    public UserDto MapToDto(User user) => new UserDto() {
        Id = user.Id.Value,
        Firstname = user.Firstname,
        SecondName = user.SecondName,
        Lastname = user.Lastname,
        Email = user.Email?.Value,
        Phone = user.Phone?.Value ?? "",
        DateOfBirth = user.DateOfBirth,
        PlaceOfBirth = user.PlaceOfBirth,
        IsStudent = user.IsStudent,
        Sex = user.Sex,
        IdentityNumber = user.PersonalIdNumber?.Value ?? "",
        JobPosition = user.JobPosition?.Title,
        Locations = user.Locations.MapToDtos().ToList(),
        Permissions = user.Permissions.Select(permission => permission.Permission.MapToDto()).ToList()
    };

    public UsersResponse MapToUsersResponse(IEnumerable<User> users) =>
        new UsersResponse(users.Select(MapToDto));
}