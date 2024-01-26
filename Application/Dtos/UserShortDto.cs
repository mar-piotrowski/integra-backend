namespace Application.Dtos;

public record UserShortDto(
    int UserId,
    string Firstname,
    string Lastname,
    string JobPosition
);