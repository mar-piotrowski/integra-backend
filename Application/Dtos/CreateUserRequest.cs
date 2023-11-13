namespace Application.Dtos;

public class CreateUserRequest {
    public string Firstname { get; init; }
    public string Lastname { get; init; }
    public string? SecondName { get; init; }
    public string Email { get; init; }
    public string? Phone { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public string? PlaceOfBirth { get; init; }
    public string? Sex { get; init; }
    public bool IsStudent { get; init; }
    public List<LocationDto>? Locations { get; init; }
}