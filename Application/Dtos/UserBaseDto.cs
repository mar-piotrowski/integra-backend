namespace Application.Dtos;

public record UserBaseDto(
    int UserId,
    string Firstname,
    string Lastname,
    string Position
);