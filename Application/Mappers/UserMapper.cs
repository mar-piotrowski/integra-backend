using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class UserMapper {
    public UserDto MapToDto(User user) => new UserDto() {
        Id = user.Id.Value,
        Firstname = user.Firstname,
        Lastname = user.Lastname,
        Email = user.Email?.Value,
        Phone = user.Phone?.Value ?? "",
        DateOfBirth = user.DateOfBirth,
        PlaceOfBirth = user.PlaceOfBirth,
        IsStudent = user.IsStudent,
        Sex = user.Sex,
        PersonalIdNumber = user.PersonalIdNumber?.Value ?? "",
        DocumentNumber = user.DocumentNumber?.Value,
        Citizenship = user.Citizenship,
        Nip = user.Nip,
        JobPosition = user.JobPosition?.Title ?? "Brak",
        BankAccount = user.BankAccount?.MapToDto(),
        Locations = user.Locations.MapToDtos().ToList(),
        Permissions = user.Permissions.Select(permission => permission.Permission.MapToDto()).ToList()
    };

    public UsersResponse MapToUsersResponse(IEnumerable<User> users) =>
        new UsersResponse(users.Select(MapToDto));

    public UserShortDto MapToShortDto(User user) => new UserShortDto(
        user.Id.Value,
        user.Firstname,
        user.Lastname
    );
}